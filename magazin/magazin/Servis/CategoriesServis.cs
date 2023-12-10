using magazin.Data;
using magazin.Model;
using magazin.ModelDto.Categorie;

using magazin.Repositories;

namespace magazin.Servis
{
    public class CategoriesServis: ICategoriesServis
    {
        private readonly ApplicationDbContext _context;

        public CategoriesServis(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriesDTO>> GetALL()
        {
            List<CategoriesDTO> categoriesDto = new List<CategoriesDTO>();

            using (var unitOfWork = new UnitOfWork(_context))
            {
                var categoriesRepository = unitOfWork.GetRepository<Category>();
                var categories = categoriesRepository.GetAll();
                foreach (var item in categories)
                {
                    categoriesDto.Add(new CategoriesDTO()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description
                    });
                }

                unitOfWork.SaveChanges();
            }

            return categoriesDto;
        }

        public async Task Add(AddCategoryDTO modelDto)
        {
            var model = new Category()
            {
                Name = modelDto.Name,
                Description =   modelDto.Description,
            };
            try
            {
                using (var unitOfWork = new UnitOfWork(_context))
                {

                    var categoriesRepository = unitOfWork.GetRepository<Category>();
                    categoriesRepository.Add(model);

                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception e)
            {
               
            }

        }

        public async Task Update(UpdateCategoryDTO modelDto)
        {
            var model = new Category()
            {
                Id = modelDto.Id,
                Name = modelDto.Name,
                Description = modelDto.Description,
            };
            try
            {
                using (var unitOfWork = new UnitOfWork(_context))
                {
                    var categoriesRepository = unitOfWork.GetRepository<Category>();
                    categoriesRepository.Update(model);
                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception e)
            {
                
            }
           
        }

        public async Task Delete(DeleteCategoryDTO modelDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoriesDTO> GetById(int id)
        {
            var modelDto = new CategoriesDTO() { };

            try
            {
                using (var unitOfWork = new UnitOfWork(_context))
                {
                    var categoriesRepository = unitOfWork.GetRepository<Category>();
                    var model = categoriesRepository.GetById(id);

                    modelDto = new CategoriesDTO()
                    {
                        Description = model.Description,
                        Name = model.Name,
                        Id = model.Id,
                    };

                    unitOfWork.SaveChanges();
                }
            }
            catch (Exception e)
            {
                
            }
            
            return modelDto;
        }
    }
}
