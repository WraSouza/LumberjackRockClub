using System.IO;
using System.Threading.Tasks;

namespace LumberjackRockClub.View.TabbedPageRestaurante
{
    internal interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}