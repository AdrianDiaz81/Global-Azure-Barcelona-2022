namespace MVP.Services
{
    public interface IAvengersService
    {
        Task<Model.AvengersListDto> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Model.AvengersDto> GetByIdAsync(string avengerId, CancellationToken cancellationToken = default);
        Task<bool> InsertAsync(Model.AvengersDto avengers, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Model.AvengersDto avengers, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(string avengerId, CancellationToken cancellationToken = default);
    }
}
