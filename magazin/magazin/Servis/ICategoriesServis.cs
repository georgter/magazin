using magazin.ModelDto.Categorie;


namespace magazin.Servis
{
    public interface ICategoriesServis
    {
        public Task<List<CategoriesDTO>> GetALL();
        public Task Add(AddCategoryDTO modelDto);
        public Task Update(UpdateCategoryDTO modelDto);
        public Task Delete(DeleteCategoryDTO modelDto);
        public Task<CategoriesDTO> GetById(int id);
    }
}
