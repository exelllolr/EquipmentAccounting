using System;
using System.Linq;
using System.Windows;
using Machine_Accounting.Models;

namespace Machine_Accounting
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new MachineAccountingEntities())
            {
                // Проверка существующего пользователя
                var existingUser = context.Users.FirstOrDefault(u => u.Username == "testuser");
                if (existingUser == null)
                {
                    // Создание нового пользователя
                    var newUser = new Users
                    {
                        FullName = "Test User",
                        Email = "testuser@example.com",
                        PhoneNumber = "1234567890",
                        Username = "testuser",
                        Password = "TestPassword123"
                    };

                    try
                    {
                        context.Users.Add(newUser);
                        context.SaveChanges();
                        MessageBox.Show("Пользователь успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                    {
                        // Вывод ошибок валидации
                        var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => $"Свойство: {x.PropertyName} Ошибка: {x.ErrorMessage}");
                        var fullErrorMessage = string.Join("\n", errorMessages);

                        MessageBox.Show($"Ошибка при добавлении пользователя:\n{fullErrorMessage}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception ex)
                    {
                        // Общая обработка исключений
                        var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Нет дополнительных деталей.";
                        var fullStackTrace = ex.ToString();
                        MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}\n\nДетали: {innerExceptionMessage}\n\nСтек вызовов: {fullStackTrace}",
                                        "Ошибка",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

    }
}




