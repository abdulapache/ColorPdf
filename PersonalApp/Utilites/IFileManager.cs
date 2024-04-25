﻿using Microsoft.AspNetCore.WebUtilities;

namespace PersonalApp.Utilites
{
    public interface IFileManager
    {
        Task<string> UploadFile(MultipartReader reader, MultipartSection section);
        Task<string> UploadFileApi(MultipartReader reader, MultipartSection section, string ApiPath);
    }
}
