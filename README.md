# EntityFramework.BulkInsert and ExpressionExtensions
在原来https://github.com/Thorium/EntityFramework.BulkInsert.git 的基础上， 批量插入时，增加了引用； 增加了ExpressionExtensions

# Purpose
1. 批量插入时，增加了引用
2. 增加了ExpressionExtensions   
# 批量插入时

```cs
	Expression<Func<SysUser, bool>> exp1 = s => s.UserName.Contains("1") && s.Age > 0;
		Expression<Func<SysUser, bool>> exp2 =exp1.And( s => s.IsEnable == 1);
		using (var context = new DbContext().ConnectionString(connString))
		{
			var result1 = context.Select<SysUser>(exp1).QueryMany();
			var result2 = context.Select<SysUser>(exp2).QueryMany();
		}
```