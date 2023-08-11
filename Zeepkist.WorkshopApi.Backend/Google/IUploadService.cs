using FluentResults;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Google;

public interface IUploadService
{
    Task<Result<string>> UploadFile(string identifier, byte[] buffer, CancellationToken ct = default);
}
