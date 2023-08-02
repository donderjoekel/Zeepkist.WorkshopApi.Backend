using FluentResults;

namespace Zeepkist.WorkshopApi.Google;

public interface IUploadService
{
    Task<Result<string>> UploadFile(string identifier, byte[] buffer, CancellationToken ct = default);
}
