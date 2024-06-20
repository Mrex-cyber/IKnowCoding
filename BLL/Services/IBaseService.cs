using BLL.Models;

namespace BLL.Services
{
    public interface IBaseService
    {
        public BaseModel GetAllModels();

        public BaseModel GetModelById(int id);

        public BaseModel CreateModel();

        public bool UpdateModel(BaseModel model);

        public bool DeleteModel(BaseModel model);
    }
}
