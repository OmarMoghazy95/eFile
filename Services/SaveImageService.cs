using System;
using System.Threading.Tasks;

namespace EFileTask.Services
{
    
   public class SaveImageService
    {
        private readonly Db.appDbContext _appDbContext;
        public SaveImageService()
        {
            _appDbContext = new Db.appDbContext();
        }
        public async Task<int> AddNewImage(Domain.Image_Data image) 
        {
            try 
            {
                if (image == null) return 0;
                _appDbContext.Image_Data.Add(image);
                return await _appDbContext.SaveChangesAsync();
            }
            catch(Exception ex) { return 0; }
        } 
    }
}
