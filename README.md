📗 ElectronicJournal — Электронный дневник

Веб-приложение для автоматизации учёта оценок учащихся. Разработано в рамках курса **«Технология разработки программных продуктов»**.


🚀 Быстрый старт

Требования
- Windows 7/10/11
- Microsoft Visual Studio 2019/2022
- .NET Framework 4.8
- IIS Express (входит в состав Visual Studio)

Установка

1. Клонируй репозиторий:git clone https://github.com/cfthdvg-bit/ElectronicJournal.git
| Возможность        | Студент         | Преподаватель            |
| ------------------ | --------------- | ------------------------ |
| Регистрация        | ✅               | ✅                        |
| Авторизация        | ✅               | ✅                        |
| Просмотр оценок    | ✅ (только свои) | ❌                        |
| Выставление оценок | ❌               | ✅ (ученикам своей школы) |
| Выход из системы   | ✅               | ✅                        |
👥 Роли пользователей
Студент
Регистрируется с указанием школы и класса
Входит по email и паролю
Просматривает свои оценки по всем предметам
Преподаватель
Регистрируется с указанием школы и предмета
Входит по email и паролю
Видит список учеников своей школы
Выставляет оценки по своему предмету
🛠 Технологический стек
| Компонент       | Технология         |
| --------------- | ------------------ |
| Язык            | C#                 |
| Платформа       | ASP.NET Web Forms  |
| Фреймворк       | .NET Framework 4.8 |
| Хранение данных | XML-файлы          |
| Стилизация      | CSS 3              |
| IDE             | Visual Studio      |

📁 Структура проекта
ElectronicJournal/
├── 📄 Default.aspx              — Главная страница
├── 📄 LogInStudent.aspx         — Вход для студента
├── 📄 LogInTeacher.aspx         — Вход для преподавателя
├── 📄 RegisterStudent.aspx      — Регистрация студента
├── 📄 RegisterTeacher.aspx      — Регистрация преподавателя
├── 📄 StudentDefault.aspx       — Личный кабинет студента
├── 📄 TeacherDefault.aspx       — Личный кабинет преподавателя
├── 📄 StudentMarks.aspx         — Просмотр оценок
├── 📄 TeacherStudents.aspx      — Выставление оценок
├── 📄 Site.master               — Главный шаблон
├── 📄 StudentSite.Master        — Шаблон студента
├── 📄 TeacherSite.Master        — Шаблон преподавателя
├── 📄 LogOutButton.ascx         — Элемент выхода
├── 📁 Styles/
│   └── Site.css                 — Стили приложения
├── 📁 App_Data/
│   ├── Students.xml             — База студентов
│   ├── Teachers.xml             — База преподавателей
│   └── Marks.xml                — База оценок
🗄 Формат данных
Students.xml
<Students>
  <Student ID="guid" FirstName="Имя" LastName="Фамилия"
           School="1" Class="10" Phone="+7..." 
           EMail="email@example.com" Password="пароль"
           RegistrationDate="2023-11-05T14:32:00" />
</Students>
Teachers.xml
<Teachers>
  <Teacher ID="guid" FirstName="Имя" LastName="Фамилия"
           School="1" Subject="Математика" Phone="+7..."
           EMail="email@example.com" Password="пароль"
           RegistrationDate="2023-08-15T09:22:34" />
</Teachers>
Marks.xml
<Marks>
  <Mark StudentID="guid" FirstName="Имя" LastName="Фамилия"
        Subject="Математика" Mark="5" 
        Date="2024-10-29T12:47:50" />
</Marks>
🎨 Интерфейс
Приложение использует зелёную цветовую схему:
Основной цвет: #068652
Акцентный: #00b86e
Фон: lightgreen
Формы: скруглённые (border-radius: 10px)

📊 Тестовые данные
Проект включает готовый набор тестовых данных:
| Сущность      | Количество |
| ------------- | ---------- |
| Студенты      | 30         |
| Преподаватели | 20         |
| Оценки        | 500+       |

⚠️ Особенности
Пароли хранятся в открытом виде (учебный проект)
Данные сохраняются в XML-файлах (без СУБД)
Используются ASP.NET Session для авторизации
Временные XML-файлы создаются для привязки к GridView
📄 Лицензия
Проект создан в образовательных целях. Свободное использование.


https://vk.com/away.php?to=https%3A%2F%2Ftelemost.yandex.ru%2Fj%2F56668677586877&utf=1
