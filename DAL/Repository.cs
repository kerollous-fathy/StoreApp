using DAL.Exceptions;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity , new()
    {
        string FileName = "";

        IConverter<T> _itemConverter;
        public Repository(IConverter<T> converter)
        {
            _itemConverter = converter;
            FileName = GetFileName();
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                var items = _itemConverter.ConvertBack(await FileHelper.ReadAll(FileName));
                return items;
            }
            catch (SerializationException eex)
            {
                return new List<T>();
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Error reading items from data source.", "list is now null", ex);
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                var items = _itemConverter.ConvertBack(await FileHelper.ReadAll(FileName));
                var item = items.Where(x => x.Id == id).FirstOrDefault();
                if (item == null)
                    return new T();
                else
                    return item;
            }
            catch (SerializationException ex)
            {
                return new T();
            }
            catch (Exception ex)
            {
                throw new DataAccessException($"Error reading item with is {id} from data source.", "item now is null", ex);
            }
        }

        public async Task Add(T model)
        {
            try
            {
                var items = await GetAll();
                items.Add(model);
                var ItemString = _itemConverter.ConvertData(items);

                await FileHelper.Create(FileName, ItemString);
            }
            catch (Exception ex)
            {
                throw new DataAccessException($"Error for adding item to data source.", "item not added", ex);
            }
        }

        public async Task Update(T model)
        {
            try
            {
                var items = await GetAll();
                var existingItem = items.Where(a => a.Id == model.Id).FirstOrDefault();
                if (existingItem != null)
                {
                    items.Remove(existingItem);
                }
                items.Add(model);
                var itemString = _itemConverter.ConvertData(items);
                await FileHelper.Create(FileName, itemString);
            }
            catch(Exception ex)
            {
                throw new DataAccessException($"Error for Updating item to data source.", "item not updated", ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                //get all items
                var items = await GetAll();
                //get item by id
                var itemToRemove = items.FirstOrDefault(x => x.Id == id);
                //remove item
                if (itemToRemove != null)
                {
                    items.Remove(itemToRemove);
                }
                //save all back
                var itemString = _itemConverter.ConvertData(items);
                await FileHelper.Update(FileName, itemString);
            }
            catch(Exception ex)
            {
                throw new DataAccessException($"Error for deleting item to data source.", "item not deleted", ex);
            }
        }

        string GetFileName()
        {
            var typeName = typeof(T).Name.ToLower();
            return $"{typeName}s.json";
        }

    }
}
