using ERG_Task.DTOs;
using ERG_Task.Models;

namespace ERG_Task.Services.impl;

public interface IPackageService
{
    public Task<Package> CreatePackageAsync(PackageDto packageDto);
    public Task<Package> GetPackageByIdAsync(int id);
    public Task<List<Package>> GetPackageAsync();
    public Task<Package> UpdatePackageAsync(int id, PackageDto packageDto);
    public Task<string> DeletePackageAsync(int id);
    public Task<List<Package>> GetPackagesByStatusAsync(int status);
    public Task<List<Package>> GetPackageByTypeIdAsync(int type);
}