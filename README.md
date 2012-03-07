# グラナダとは

グラナダはASP.NET WebForm向けのヘルパークラスです。
以下の機能を提供します。

* セッションに格納した値へのアクセス
* クエリストリング付けたページへのリダイレクト

# インストール

NuGetでインストールしてください。IDはGranadaです。

# 使い方

## セッション

```c#
SesiionHelper.Hoge.Set("hoge");
if(SesiionHelper.Hoge.IsExist)
string hoge = SessionHelper.Hoge;
```

## リダイレクト

```c#
var n = New NextPage("http://example.com/index.html")
n.AddQuery(key, val).Go()
```


## バージョン

* 0.0.1 NUnitのテストがありますが機能していません。MSTestで書き直し予定です。