using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Granada.UI
{
    /// <summary>
    /// Controlから子要素をFindControlし、発見した子要素の属性を操作する拡張メソッドです。
    /// 以下のルールでメソッドを命名しています。
    /// [Get/Set][子要素の型][操作対象の属性]
    /// 
    /// 第一引数に操作対象の子要素の名前を指定します。
    /// セッターの場合、第二引数以降が設定する値です。
    /// </summary>
    public static class FindControlExtentions
    {
        /// <summary>
        /// Enabled属性を設定します。
        /// WebControlならどのコントロールでも設定できるので子要素の型毎のメソッドに分けていません。
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetEnabled(this Control c, string name, bool value)
        {
            ((WebControl)FindControl(c, name)).Enabled = value;
        }

        /// <summary>
        /// Visible属性を設定します。
        /// WebControlならどのコントロールでも設定できるので子要素の型毎のメソッドに分けていません。
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetVisible(this Control c, string name, bool value)
        {
            ((WebControl)FindControl(c, name)).Visible = value;
        }

        #region ラベル
        /// <summary>
        /// ラベルのText属性を取得します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetLabelText(this Control c, string name)
        {
            return ((Label)FindControl(c, name)).Text;
        }

        /// <summary>
        /// ラベルのText属性を設定します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetLabelText(this Control c, string name, string value)
        {
            ((Label)FindControl(c, name)).Text = value;
        }
        #endregion

        #region テキストボックス
        /// <summary>
        /// テキストボックスのText属性を取得します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetTextBoxText(this Control c, string name)
        {
            return ((TextBox)FindControl(c, name)).Text;
        }

        /// <summary>
        /// テキストボックスのText属性を設定します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetTextBoxText(this Control c, string name, string value)
        {
            ((TextBox)FindControl(c, name)).Text = value;
        }
        #endregion

        #region チェックボックス
        /// <summary>
        /// チェックボックスのCheckBox属性を取得します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetCheckBoxChecked(this Control c, string name)
        {
            return ((CheckBox)FindControl(c, name)).Checked;
        }

        /// <summary>
        /// チェックボックスのCheckBox属性を設定します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetCheckBoxChecked(this Control c, string name, bool value)
        {
            ((CheckBox)FindControl(c, name)).Checked = value;
        }
        #endregion

        #region ハイパーリンク
        /// <summary>
        /// ハイパーリンクのNavigateUrl属性を取得します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetHyperLinkNavigateUrl(this Control c, string name)
        {
            return ((HyperLink)FindControl(c, name)).NavigateUrl;
        }

        /// <summary>
        /// ハイパーリンクのNavigateUrl属性を設定します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetHyperLinkNavigateUrl(this Control c, string name, string value)
        {
            ((HyperLink)FindControl(c, name)).NavigateUrl = value;
        }
        #endregion

        #region ドロップダウンリスト
        /// <summary>
        /// ドロップダウンリストのItems属性を取得します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ListItemCollection GetDropDownListItems(this Control c, string name)
        {
            return ((DropDownList)FindControl(c, name)).Items;
        }

        /// <summary>
        /// ドロップダウンリストにデータをバインドします。
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="value">DataSourceに設定する値</param>
        /// <param name="selectedIndex">SelectedIdex</param>
        public static void SetDropDownListDataBind(this Control c, string name, object value, int selectedIndex = 0)
        {
            c.SetDataBoundControlDataBind(name, value);
            c.SetDropDownListSelectedIndex(name, selectedIndex);
        }

        /// <summary>
        /// ドロップダウンリストのSelectedIndex属性を取得します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GetDropDownListSelectedIndex(this Control c, string name)
        {
            return ((DropDownList)FindControl(c, name)).SelectedIndex;
        }

        /// <summary>
        /// ドロップダウンリストのSelectedIndex属性を設定します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetDropDownListSelectedIndex(this Control c, string name, int value)
        {
            ((DropDownList)FindControl(c, name)).SelectedIndex = value;
        }

        /// <summary>
        /// ドロップダウンリストのSelectedValue属性を取得します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetDropDownListSelectedValue(this Control c, string name)
        {
            return ((DropDownList)FindControl(c, name)).SelectedValue;
        }

        /// <summary>
        /// ドロップダウンリストのSelectedValue属性を設定します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetDropDownListSelectedValue(this Control c, string name, string value)
        {
            ((DropDownList)FindControl(c, name)).SelectedValue = value;
        }

        /// <summary>
        /// BaseDataBoundControlにデータをバインドします
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetDataBoundControlDataBind(this Control c, string name, object value)
        {
            var a = ((BaseDataBoundControl)FindControl(c, name));
            a.DataSource = value;
            a.DataBind();
        }
        #endregion

        #region ボタン
        /// <summary>
        /// ボタンのCmmandName属性を設定します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="commandName"></param>
        /// <param name="commandArgument"></param>
        public static void SetButtonCommandName(this Control c, string name, string commandName)
        {
            var button = (Button)FindControl(c, name);
            button.CommandName = commandName;
        }

        /// <summary>
        /// ボタンのCmmandName属性とCommandArgment属性を設定します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="commandName"></param>
        /// <param name="commandArgument"></param>
        public static void SetButtonCommandArgument(this Control c, string name, string commandArgument)
        {
            var button = (Button)FindControl(c, name);
            button.CommandArgument = commandArgument;
        }

        /// <summary>
        /// ボタンのCmmandName属性とCommandArgment属性を設定します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="commandName"></param>
        /// <param name="commandArgument"></param>
        public static void SetButtonCommandNameAndCommandArgument(this Control c, string name, string commandName, string commandArgument)
        {
            var button = (Button)FindControl(c, name);
            button.CommandName = commandName;
            button.CommandArgument = commandArgument;
        }
        #endregion

        #region 隠しフィールド
        /// <summary>
        /// 隠しフィールドのValue属性を取得します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetHiddenFieldValue(this Control c, string name)
        {
            return ((HiddenField)FindControl(c, name)).Value;
        }

        /// <summary>
        /// 隠しフィールドのValue属性を設定します
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetHiddenFieldValue(this Control c, string name, string value)
        {
            ((HiddenField)FindControl(c, name)).Value = value;
        }
        #endregion

        #region プライベートメソッド
        private static Control FindControl(Control c, string name)
        {
            var target = c.FindControl(name);
            if (target == null)
            {
                throw new ArgumentException(string.Format("コントロールに子要素:{0}はありません。", name), "name");
            }
            else
            {
                return target;
            }
        }
        #endregion
    }
}
