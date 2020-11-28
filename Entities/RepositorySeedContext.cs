using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Enums;

namespace Entities
{
    /// <summary>
    /// Seed content method
    /// </summary>
    public static class RepositorySeedContext
    {
        public static async Task Initialize(RepositoryContext context)
        {
            // Define test values
            if (!await context.Values.AnyAsync())
            {
                var values = new List<ValueEntity>
                {
                    new ValueEntity
                    {
                        Description = "Value 1",
                    },
                    new ValueEntity
                    {
                        Description = "Value 2",
                    }
                };

                await context.AddRangeAsync(values);
                await context.SaveChangesAsync();
            }

            if (!await context.Users.AnyAsync())
            {
                var users = new List<UserEntity>
                {
                    new UserEntity
                    {
                        Name = "Сергей Попов",
                        Picture = "assets/images/alan.png",
                        Progress = 12,
                        Level = LanguageLevelEnum.Elementary,
                        LastActivityTime = DateTime.Now.AddDays(-1),
                        Notification = NotificationEnum.Info,
                        PaymentLevel = PaymentLevelEnum.Base
                    },
                    new UserEntity
                    {
                        Name = "Елизавета Сергеева",
                        Picture = "assets/images/eva.png",
                        Progress = 27,
                        Level = LanguageLevelEnum.Beginner,
                        LastActivityTime = DateTime.Now.AddDays(-3),
                        Notification = NotificationEnum.Warning,
                        PaymentLevel = PaymentLevelEnum.Base
                    },
                    new UserEntity
                    {
                        Name = "Александр Васильев",
                        Picture = "assets/images/nick.png",
                        Progress = 46,
                        Level = LanguageLevelEnum.Intermediate,
                        LastActivityTime = DateTime.Now,
                        Notification = NotificationEnum.None,
                        PaymentLevel = PaymentLevelEnum.Premium
                    },
                    new UserEntity
                    {
                        Name = "Lee Wang",
                        Picture = "assets/images/lee.png",
                        Progress = 62,
                        Level = LanguageLevelEnum.UpperIntermediate,
                        LastActivityTime = DateTime.Now.AddDays(-5),
                        Notification = NotificationEnum.Danger,
                        PaymentLevel = PaymentLevelEnum.Ultimate
                    },
                    new UserEntity
                    {
                        Name = "Богдан Марков",
                        Picture = "assets/images/jack.png",
                        Progress = 33,
                        Level = LanguageLevelEnum.Advanced,
                        LastActivityTime = DateTime.Now.AddDays(-1),
                        Notification = NotificationEnum.Warning,
                        PaymentLevel = PaymentLevelEnum.Base
                    },
                    new UserEntity
                    {
                        Name = "Светлана Полякова",
                        Picture = "assets/images/kate.png",
                        Progress = 89,
                        Level = LanguageLevelEnum.Proficiency,
                        LastActivityTime = DateTime.Now.AddHours(-3),
                        Notification = NotificationEnum.Info,
                        PaymentLevel = PaymentLevelEnum.Ultimate
                    }
                };

                await context.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }

            if (!await context.Categories.AnyAsync())
            {

                var categories = new List<CategoryEntity>
                {
                    new CategoryEntity
                    {
                        TitleRu = "Сценарии",
                        TitleEn = "Scenarios",
                        DescriptionRu = "Продемонстрируй сценарий из реальной жизненной ситуации",
                        DescriptionEn = "Demonstrate a scenario from a real life situation",
                        Tasks = new List<TaskEntity>
                        {
                            new TaskEntity
                            {
                                TitleRu = "Ты собираешься посетить другую страну",
                                TitleEn = "Are you going to visit another country",
                                DescriptionRu = "Договорись остановиться на несколько дней у незнакомого тебе человека и продумайте вместе с ним чем вы будете заниматься в твоем отпуске",
                                DescriptionEn = "We agreed to stay for a few days with a person you don't know and work out with them what you will do on your vacation"
                            },
                            new TaskEntity
                            {
                                TitleRu = "Приготовь национальное блюдо другой страны",
                                TitleEn = "Prepare a national dish of another country",
                                DescriptionRu = "Созвонись с представителем другой страны и пусть он поможет тебе приготовить их национальное блюдо",
                                DescriptionEn = "Call a representative of another country and let them help you prepare their national dish"
                            }
                        }
                    },
                    new CategoryEntity
                    {
                        TitleRu = "Спорт",
                        TitleEn = "Sport",
                        DescriptionRu = "Задания на спортивную тематику",
                        DescriptionEn = "Sports-related tasks",
                        Tasks = new List<TaskEntity>
                        {
                            new TaskEntity
                            {
                                TitleRu = "Расставь буквы",
                                TitleEn = "Arrange the letters",
                                DescriptionRu = "Существует цепочка чисел; ваша задача состоит в том, чтобы расшифровать слова с помощью алфавита и перевести их.",
                                DescriptionEn = "There is a chain of numbers; your task is to decode the words using the alphabet and translate them.",
                                Text = "19, 16, 15, 18, 20, 19, 13, 1, 14",
                                Answer = "sportsman"
                            },
                            new TaskEntity
                            {
                                TitleRu = "Отгадай кто это?",
                                TitleEn = "Guess who it is?",
                                DescriptionRu = "Произнеси слово, которое загадано",
                                DescriptionEn = "Say the word that is hidden",
                                Text = "Windsurfing",
                                Answer = "surfer"
                            },
                            new TaskEntity
                            {
                                TitleRu = "Перепутанные буквы",
                                TitleEn = "Mixed up letters",
                                DescriptionRu = "Расставьте Буквы в словах по теме Спорт в логическом порядке.",
                                DescriptionEn = "Put the letters in the words on the topic Sport in a logical order.",
                                Text = "rocsaebi",
                                Answer = "aerobics"
                            },
                            new TaskEntity
                            {
                                TitleRu = "Цепочка слов",
                                TitleEn = "Chain of words",
                                DescriptionRu = "Тебе дается исходное слово, из которого ты должен составить цепочку слов, где последняя буква предыдущего слова является первой буквой последующего",
                                DescriptionEn = "You are given the original word, from which you must make a chain of words, where the last letter of the previous word is the first letter of the next",
                                Text = "sport",
                                Answer = "sport,tennis,surfing,gymnastics,sailing"
                            },
                            new TaskEntity
                            {
                                TitleRu = "Угадай спортивную игру",
                                TitleEn = "Guess the sports game",
                                DescriptionRu = "",
                                DescriptionEn = "",
                                Text = "What game is played between 2 teams of eleven players?",
                                Answer = "Football"
                            },
                            new TaskEntity
                            {
                                TitleRu = "Перепутанные слова",
                                TitleEn = "Mixed up words",
                                DescriptionRu = "Поставьте слова в логическом порядке.",
                                DescriptionEn = "Put the words in the logical order. ",
                                Text = "body sound a sound in mind a",
                                Answer = "A sound mind in a sound body"
                            }
                        }
                    },
                    new CategoryEntity
                    {
                        TitleRu = "Кулинария",
                        TitleEn = "Cooking",
                        DescriptionRu = "Поваренное искусство",
                        DescriptionEn = "Cooking art",
                        Tasks = new List<TaskEntity>
                        {
                            new TaskEntity
                            {
                                TitleRu = "Представьте, что вы в ресторане с своим другом",
                                TitleEn = "Imagine that you are in a restaurant with your friend",
                                DescriptionRu = "",
                                DescriptionEn = "",
                                Text = "Попросите столик на двоих у окна"
                            },
                            new TaskEntity
                            {
                                TitleRu = "Представьте, что вы в ресторане с своим другом",
                                TitleEn = "Imagine that you are in a restaurant with your friend",
                                DescriptionRu = "",
                                DescriptionEn = "",
                                Text = "Спросите у официанта, помнит ли он, какой десерт вы заказывали",
                                Answer = ""
                            },
                            new TaskEntity
                            {
                                TitleRu = "Представьте, что вы в ресторане с своим другом",
                                TitleEn = "Imagine that you are in a restaurant with your friend",
                                DescriptionRu = "",
                                DescriptionEn = "",
                                Text = "Попросите официанта сделать потише или выключить музыку, потому что вы не можете разговаривать",
                                Answer = ""
                            }
                        }
                    }
                };

                await context.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            // генерируем рандомное кол-во заданий для каждого юзера (для инициализации)
            if (!await context.UserTasks.AnyAsync())
            {
                var users = await context.Users.ToListAsync();
                var tasks = await context.Tasks.ToListAsync();

                foreach (var userTask in 
                    from user in users 
                    let taskCount = new Random().Next(3, 9) 
                    let neededTasks = tasks.OrderBy(arg => Guid.NewGuid()).Take(taskCount) 
                    from task in neededTasks 
                    select new UserTaskEntity
                    {
                        UserId = user.Id,
                        TaskId = task.Id
                    })
                {
                    await context.AddAsync(userTask);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
