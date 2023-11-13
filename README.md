# Dashboards

## iTamerlan / WebAppApiDashBoard

[![All Contributors](https://img.shields.io/github/contributors/iTamerlan/WebAppApiDashBoard)](#contributors-)
![Issues](https://img.shields.io/github/issues/iTamerlan/WebAppApiDashBoard)
![Pull Requests](https://img.shields.io/github/issues-pr/iTamerlan/WebAppApiDashBoard?)
![Forks](https://img.shields.io/github/forks/iTamerlan/WebAppApiDashBoard)
![Stars](https://img.shields.io/github/stars/iTamerlan/WebAppApiDashBoard)
![License](https://img.shields.io/github/license/iTamerlan/WebAppApiDashBoard)

## Translations
<kbd>[<img title="Русский" alt="Русский" src="https://gcore.jsdelivr.net/gh/hampusborgos/country-flags@main/svg/ru.svg" width="22">](https://github.com/iTamerlan/WebAppApiDashBoard)</kbd>

## Возможности

- Service, Repositories, Controller, Dto для следующих предметных областей:
-- Bidding (аукцион)
-- Bookmark (Закладки)
-- Category (Категории)
-- Comment (Комментарии)
-- Community (Сообщества)
-- Feedback (Отзывы)
-- History (История просмотра)
-- Post (Посты/Объявления)
-- Product (Товары)
-- Tag (Теги)
-- User (Пользователи)
-- Voting (Голосование)

## ✅ Текущее развитие

- Edit Controller/Services

##  👀  Как начать использовать проект?

В терминале с помощью команды cd перейдите в целевую папку для проекта.
Для создания локальной копии проекта запустите эту команду в своем терминале:

```bash
git clone https://github.com/iTamerlan/TamerlanDashboard.git
```

Запустив Docker Desktop или аналигочный способ запуска служб Docker. Далее в терминале перейдите в папку проекта, где лежит файла docker-compose.yml, и выполните команду:

```bash
docker-compose up -d
```

Эта команда запустит контейнер с postgres.

В Visual Studio в консоли диспетчера пакетов выполните команду миграции:

```bash
EntityFramework6\Update-Database
```

Dashboard.Hosts.Api готов к запуску!

## ⚠️ Disclaimer

Проект находится на этапе разработке.

Ни при каких обстоятельствах iTamerlan не несет ответственности за какие-либо прямые, косвенные, специальные или случайные убытки, включая, но не ограничиваясь, потерей данных, прибыли или интеллекта, возникающих из-за использования или невозможности использования данного Проекта, даже если iTamerlan или уполномоченный представитель был уведомлен о возможности такого ущерба.

Автор оставляет за собой право вносить дополнения, удаления или изменения, а также класть болт на Проект в любое время без предварительного уведомления.