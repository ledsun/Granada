# �O���i�_�Ƃ�

�O���i�_��ASP.NET WebForm�����̃w���p�[�N���X�ł��B
�ȉ��̋@�\��񋟂��܂��B

* �Z�b�V�����Ɋi�[�����l�ւ̃A�N�Z�X
* �N�G���X�g�����O�t�����y�[�W�ւ̃��_�C���N�g

# �C���X�g�[��

NuGet�ŃC���X�g�[�����Ă��������BID��Granada�ł��B

# �g����

## �Z�b�V����

```c#
SesiionHelper.Hoge.Set("hoge");
if(SesiionHelper.Hoge.IsExist)
string hoge = SessionHelper.Hoge;
```

## ���_�C���N�g

```c#
var n = New NextPage("http://example.com/index.html")
n.AddQuery(key, val).Go()
```


## �o�[�W����

* 0.0.1 NUnit�̃e�X�g������܂����@�\���Ă��܂���BMSTest�ŏ��������\��ł��B