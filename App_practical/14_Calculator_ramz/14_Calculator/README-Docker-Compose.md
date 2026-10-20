# Калькулятор + MariaDB (Docker Compose)

## Запуск локально
1. Установите Docker Desktop и запустите его.
2. Откройте терминал в каталоге `14_Calculator/14_Calculator`, где лежит `docker-compose.yml`.
3. Выполните `docker compose up --build -d`.
4. Откройте `http://localhost:5014`. Успешные вычисления сохраняются в таблицу `DataInputVariants`.
5. Проверить контейнеры: `docker compose ps`; логи: `docker compose logs -f web`.
6. Остановить: `docker compose down`. Данные БД хранятся в томе `mariadb_data`; для удаления данных отдельно выполните `docker compose down -v`.

## HeidiSQL
- Host: `127.0.0.1`
- Port: `5033`
- User: `webcalc`
- Password: значение `MARIADB_PASSWORD` (по умолчанию `local_webcalc_password`)
- Database: `14-WebCalculatorDb`

## Подключение из Visual Studio и миграции
В Docker-сети имя сервера базы данных — `mariadb`, порт — `3306`. На хост-компьютере используется `127.0.0.1:5033`.
Пакеты EF Core и Pomelo для MariaDB добавлены в `.csproj`. В проект добавлена начальная миграция `m_init`; приложение применяет её при старте через `Database.MigrateAsync()`. Если будете менять модель, в Package Manager Console выполните `Add-Migration имя_миграции`, затем `Update-Database`.

## GitHub
Перед публикацией проверьте `git status`, добавьте `.gitignore` для `.vs/`, `bin/`, `obj/`, `*.user` и не публикуйте реальные пароли.
