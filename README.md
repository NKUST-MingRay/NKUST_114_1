# Nkust_114_1

## 專案說明

這是一個使用 **.NET 9.0** 開發的主控台應用程式，用於讀取並分析「河川水位測站基本資料」的 JSON 檔案。  
程式會：

- 從 `App_Data/affdata.json` 載入測站基本資料  
- 反序列化為 C# 物件  
- 讓使用者輸入關鍵字，**搜尋測站名稱中包含該關鍵字的測站**，並在終端機中列出結果

本專案可作為「讀取政府開放資料 → 解析 JSON → 進行簡易查詢」的示範範例。

---

## 資料來源

本專案使用之資料為課堂提供的「河川水位測站基本資料」 JSON 檔案，原始資料來源為政府開放資料平台之水利相關資料集（例如水利署水文開放資料）。

> 實際使用之檔案名稱：`affdata.json`  
> 檔案內容為多筆測站屬性資料的 JSON 陣列（Array of objects）。

---

## 資料準備

1. 在專案的 `ConsoleApp` 目錄底下建立 `App_Data` 資料夾（若尚未存在）：
   ```
   ConsoleApp/App_Data/
   ```

2. 將 `affdata.json` 放入 `ConsoleApp/App_Data/` 資料夾中。

3. 在 Visual Studio 中選取 `affdata.json` 檔案，於屬性視窗設定：

   - **Build Action**：`None`（或 `Content` 皆可）
   - **Copy to Output Directory**：`Copy if newer`

---

## 開發環境需求

- **.NET 9.0 SDK**

---

## 專案執行方式

### 1. 進入專案資料夾

```bash
cd NKUST_114_1
```

### 2. 建置專案

```bash
dotnet build
```

### 3. 執行主控台應用程式

```bash
dotnet run --project ConsoleApp
```

或先進入 ConsoleApp 目錄後再執行：

```bash
cd ConsoleApp
dotnet run
```

---

## 功能說明

### 1. 讀取 JSON 資料

程式啟動後會自動從輸出目錄中的 `App_Data/affdata.json` 載入「河川水位測站基本資料」。  
載入後，系統會將 JSON 內容轉換為可供程式操作的資料物件，作為後續查詢與搜尋的來源。

---

### 2. 測站名稱關鍵字搜尋（示範功能）

成功載入資料後，系統會要求使用者輸入任意關鍵字。  
程式會從所有測站資料中，搜尋名稱欄位（observatoryname）包含該關鍵字的測站，並將所有符合條件的結果列出。

搜尋後的輸出內容包括：

- 測站名稱  
- 測站代碼  
- 河川名稱  
- 位置地址  
- 測站狀態  

此功能示範了資料過濾（搜尋）、資料呈現與 JSON 解析後的實際應用。

---

## 專案結構說明

```
NKUST_114_1/
├── ConsoleApp/
│   ├── ConsoleApp.csproj
│   ├── Program.cs
│   ├── AffStation.cs
│   ├── ConsoleApp.sln
│   └── App_Data/
│       └── affdata.json
└── README.md
```

---

## 備註

- `App_Data` 資料夾需手動建立並放入 JSON 檔案。
- 若 JSON 欄位更新，需同步更新 `AffStation` 類別。
