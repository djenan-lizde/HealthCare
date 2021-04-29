using System.IO;
using System.Threading.Tasks;

namespace ePregledi.MobileApp.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
