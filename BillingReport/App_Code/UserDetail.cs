
/// <summary>
/// Summary description for UserDetail
/// </summary>
public class UserDetail
{
    private int _userid;
    public int UserID
    {
        get
        {
            return this._userid;
        }
        set { this._userid = value; }
    }

    private string _userName = string.Empty;

    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }

    private string _defaultPanelID = string.Empty;

    public string DefaultPanelID
    {
        get { return _defaultPanelID; }
        set { _defaultPanelID = value; }
    }

    private string _operatorfullname = string.Empty;

    public string OperatorFullName
    {
        get { return _operatorfullname; }
        set { _operatorfullname = value; }
    }
}