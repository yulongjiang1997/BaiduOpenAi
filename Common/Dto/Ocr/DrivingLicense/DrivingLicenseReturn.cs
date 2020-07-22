public class 姓名
{
    /// <summary>
    /// 崔家森
    /// </summary>
    public string words { get; set; }
}

public class 至
{
    /// <summary>
    /// 
    /// </summary>
    public string words { get; set; }
}

public class 出生日期
{
    /// <summary>
    /// 
    /// </summary>
    public string words { get; set; }
}

public class 证号
{
    /// <summary>
    /// 
    /// </summary>
    public string words { get; set; }
}

public class 住址
{
    /// <summary>
    /// 湖北省秭归县茅坪镇
    /// </summary>
    public string words { get; set; }
}

public class 初次领证日期
{
    /// <summary>
    /// 
    /// </summary>
    public string words { get; set; }
}

public class 国籍
{
    /// <summary>
    /// 中国
    /// </summary>
    public string words { get; set; }
}

public class 准驾车型
{
    /// <summary>
    /// 
    /// </summary>
    public string words { get; set; }
}

public class 性别
{
    /// <summary>
    /// 男
    /// </summary>
    public string words { get; set; }
}

public class 有效期限
{
    /// <summary>
    /// 
    /// </summary>
    public string words { get; set; }
}

public class Words_result
{
    /// <summary>
    /// 
    /// </summary>
    public 姓名 姓名 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public 至 至 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public 出生日期 出生日期 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public 证号 证号 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public 住址 住址 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public 初次领证日期 初次领证日期 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public 国籍 国籍 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public 准驾车型 准驾车型 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public 性别 性别 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public 有效期限 有效期限 { get; set; }
}

public class DrivingLicenseReturn
{
    /// <summary>
    /// 
    /// </summary>
    public Words_result words_result { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long log_id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int words_result_num { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int direction { get; set; }
}
