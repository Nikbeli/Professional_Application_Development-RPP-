using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyDataModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.BussinessLogic
{
    // Класс, реализующий логику для BackUp
    public class BackUpLogic : IBackUpLogic
    {
        private readonly ILogger _logger;

        private readonly IBackUpInfo _backUpInfo;

        // Конструктор
        public BackUpLogic(ILogger<BackUpLogic> logger, IBackUpInfo backUpInfo)
        {
            _logger = logger;
            _backUpInfo = backUpInfo;
        }

        public void CreateBackUp(BackUpSaveBindingModel model)
        {
            // Проверка наличия данных для бэкапа
            if (_backUpInfo == null)
            {
                return;
            }

            try
            {
                _logger.LogDebug("Clear folder");

                // Зачистка папки и удаление старого архива
                var dirInfo = new DirectoryInfo(model.FolderName);

                if (dirInfo.Exists)
                {
                    // ЛУЧШЕ ВЫБИРАТЬ ОТДЕЛЬНО СОЗДАННУЮ ПАПКУ (Рабочий стол не использовать, поскольку с него всё удалится)
                    foreach (var file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }

                _logger.LogDebug("Delete archive");

                string fileName = $"{model.FolderName}.zip";

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Берём метод для сохранения
                _logger.LogDebug("Get assembly");

                // Получение сборки и типов
                var typeIId = typeof(IId);
                var assembly = typeIId.Assembly;

                if (assembly == null)
                {
                    throw new ArgumentNullException("Сборка не найдена", nameof(assembly));
                }

                var types = assembly.GetTypes();
                var method = GetType().GetMethod("SaveToFile", BindingFlags.NonPublic | BindingFlags.Instance);

                _logger.LogDebug("Find {count} types", types.Length);

                // Перебор типов и вызов метода для сохранения данных
                foreach (var type in types)
                {
                    // Проверка на то, является ли тип интерфейсом и унаследован ли он от IId
                    if (type.IsInterface && type.GetInterface(typeIId.Name) != null)
                    {
                        var modelType = _backUpInfo.GetTypeByModelInterface(type.Name);

                        if (modelType == null)
                        {
                            throw new InvalidOperationException($"Не найден класс - модель для {type.Name}");
                        }

                        _logger.LogDebug("Call SaveToFile method for {name} type", type.Name);

                        // Вызываем метод на выполнение (Вызываем метод типа MethodInfo)
                        method?.MakeGenericMethod(modelType).Invoke(this, new object[] { model.FolderName });
                    }
                }

                _logger.LogDebug("Create zip and remove folder");

                // Архивируем
                ZipFile.CreateFromDirectory(model.FolderName, fileName);

                // Удаляем папку
                dirInfo.Delete(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveToFile<T>(string folderName) where T : class, new()
        {
            var records = _backUpInfo.GetList<T>();

            if (records == null)
            {
                _logger.LogWarning("{type} type get null list", typeof(T).Name);

                return;
            }

            // Три строчки ниже - сериализация файлов в json
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));

            using var fs = new FileStream(string.Format("{0}/{1}.json", folderName, typeof(T).Name), FileMode.OpenOrCreate);

            jsonFormatter.WriteObject(fs, records);
        }
    }
}
