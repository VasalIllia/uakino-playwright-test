# UAKino.UiTests

Автоматизовані UI-тести для [UAKino](https://uakino.best/ua/) на **C#**, **Playwright** та **NUnit** (.NET 10).

## Швидкий старт

1. **Збірка проєкту:**
   ```bash
   dotnet build
   ```

2. **Встановлення браузерів (виконується один раз):**
   ```powershell
   pwsh bin/Debug/net10.0/playwright.ps1 install
   ```

3. **Запуск тестів:**
   ```bash
   dotnet test
   ```
   *З відкриттям вікна браузера (Windows):* `$env:HEADED="1"; dotnet test`

## Трейсинг (Playwright Tracing)

Для запису кроків виконання тесту розкоментуйте `[SetUp]` та `[TearDown]` у `UAKinoTests/HomePageTracingTest.cs`.

Після запуску архів збережеться у `PageTested/playwright-traces/`. Переглянути його можна командою:
```powershell
pwsh bin/Debug/net10.0/playwright.ps1 show-trace PageTested/playwright-traces/HomePageTracingTest.VisibleFilmBanner.zip
```
*(Або перетягнути `.zip` файл на [trace.playwright.dev](https://playwright.dev)).*

## ⚙️ CI/CD
Тести автоматично запускаються при `push` / `pull request` через GitHub Actions (`.github/workflows/playwright.yml`).