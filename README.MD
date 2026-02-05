# ENG: LeaderboardFix for Crime Simulator

A BepInEx plugin for Crime Simulator that fixes Steam leaderboard issues caused by using mods.

## Features

- **Mod detection bypass** — Prevents the game from detecting mods so leaderboard scores are still uploaded
- **Cheat Engine/WeMod check removal** — Removes the `UsedCheats` flag and bypasses cheat detection
- **Leaderboard upload fix** — Patches `UploadScore` method to correctly upload scores via Steamworks API

## Installation

1. Install [BepInEx](https://github.com/BepInEx/BepInEx) for Crime Simulator
2. Copy `Plugin.dll` to `BepInEx/plugins/` folder
3. Launch the game

## Technical Details

- Plugin ID: `com.ic23.leaderboardfix`
- Plugin Name: `LeaderboardFix`
- Version: `1.0.0`
- Target Framework: .NET Standard 2.1
- Dependencies: BepInEx, Harmony

---

# RU: LeaderboardFix для Crime Simulator

BepInEx плагин для Crime Simulator, который исправляет проблемы с таблицами лидеров Steam при использовании модов.

## Возможности

- **Обход обнаружения модов** — Игра перестаёт определять наличие модов, очки начинают загружаються в таблицу лидеров
- **Удаление проверки на Cheat Engine/WeMod** — Убирает флаг `UsedCheats` и обходит проверки на читы (`IsCheatRunning`, `PerformCheatCheck`)
- **Исправление загрузки очков** — Патчит метод `UploadScore` для корректной загрузки очков через Steamworks API

## Установка

1. Установите [BepInEx](https://github.com/BepInEx/BepInEx) для Crime Simulator
2. Скопируйте `Plugin.dll` в папку `BepInEx/plugins/`
3. Запустите игру

## Технические детали

- ID плагина: `com.ic23.leaderboardfix`
- Название: `LeaderboardFix`
- Версия: `1.0.0`
- Целевой фреймворк: .NET Standard 2.1
- Зависимости: BepInEx, Harmony

## Лицензия / License

MIT