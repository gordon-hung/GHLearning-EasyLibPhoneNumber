# GHLearning - EasyLibPhoneNumber

簡短說明：此專案為一個使用 `libphonenumber-csharp` 的 .NET Web API 範例（目標為 .NET 10）。

## 專案架構

```
GHLearning-EasyLibPhoneNumber/
├─ src/
│  └─ GHLearning.EasyLibPhoneNumber.WebApi/
│     └─ GHLearning.EasyLibPhoneNumber.WebApi.csproj
```

- 專案檔：`src/GHLearning.EasyLibPhoneNumber.WebApi/GHLearning.EasyLibPhoneNumber.WebApi.csproj`
- 目標框架：`net10.0`

## 相依套件清單

此專案在 `csproj` 中引用的套件：

- `libphonenumber-csharp` — Version `9.0.26`  
  用於解析與格式化電話號碼（基於 Google libphonenumber 的 C# 移植）。
- `Microsoft.AspNetCore.OpenApi` — Version `10.0.4`  
  用於產生 OpenAPI / Swagger 支援。
- `Scalar.AspNetCore` — Version `2.13.17`  
  提供對大型儲存庫（monorepo）友善的 Git 優化整合（視專案需求可能用於 CI/開發流程）。

此外 `csproj` 已啟用：

- `Nullable`：`enable`
- `ImplicitUsings`：`enable`

## 快速啟動

在專案根目錄執行：

```
dotnet restore
dotnet build
dotnet run --project src/GHLearning.EasyLibPhoneNumber.WebApi
```

如需進一步說明或要加入使用範例，請告知要補充的部分。
