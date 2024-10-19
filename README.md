# MiddleSchool.Homework6

## Запуск

1. Запустить базу данных из docker-compose файла в корне репозитория:
   ```shell
   docker compose up -d
   ```
2. Выполнить миграции для создания таблиц с помощью запуска проекта мигратора `MiddleSchool.Homework6.Migrator` через IDE или командой:
   ```shell
   dotnet run --project MiddleSchool.Homework6.Migrator
   ```
3. Запустить проект с API `MiddleSchool.Homework6.Api` через IDE или командой:
   ```shell
   dotnet run --project MiddleSchool.Homework6.Api
   ```
4. В браузере по адресу http://localhost:5272/swagger/index.html будет доступен swagger с примерами запросов и ответов и возможностью выполнить их.