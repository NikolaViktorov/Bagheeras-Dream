namespace BagheerasDream.Services.Data
{
	using System;
	using System.IO;

	using Microsoft.AspNetCore.Http;

	public static class ImageUploader
	{
		public static string UploadFile(IFormFile file, string folderName)
		{
			string fileName = null;
			if (file != null)
			{
				string baseFolderPath = Path.GetFullPath(
					Path.Combine(
						Directory.GetCurrentDirectory(), "@../../")
					);
				string clientFolderPath = baseFolderPath + "\\wwwroot\\pictures";
				string uploadDir = Path.Combine(clientFolderPath, folderName);
				fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
				string filePath = Path.Combine(uploadDir, fileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					file.CopyTo(fileStream);
				}
			}

			return fileName;
		}
	}
}
