---
category: Components
type: 数据录入
title: InputNumber
subtitle: 数字输入框
---

通过鼠标或键盘，输入范围内的数值。

## 何时使用

- 当需要获取标准数值时。



## API

| 参数             | 说明                                         | 类型          | 默认值    |
| ---------------- | -------------------------------------------- | ------------- | --------- |
| AutoFocus | 自动获取焦点                              | boolean        | -         |
| DefaultValue            | 初始值           | number         |
| Disabled            |禁用           | boolean         |-       |
| Formatter |指定输入框展示值的格式      | function(double,string)        | -         |
| Max              | 最大值       | number        | -        |
| Min |  	最小值                            | number        | -         |
| Parser | 指定从 `formatter` 里转换回数字的方式，和 `formatter` 搭配使用        | function(string, double)           |
| Size | 	输入框大小                            | `large` ,`middle`,`small`        | -        |
| Step | 每次改变步数，可以为小数                            | double        | -         |
| Value            |当前值 | string  | -         |
| ValueChanged |输入框内容变化时的回调                     | function(double)        | -        |



