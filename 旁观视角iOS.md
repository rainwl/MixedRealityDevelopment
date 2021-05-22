# 面对旁观视角对iOS要求怎么做

## macOS首先安装cocopods

打开终端
输入命令：`sudo gem install cocoapods`
等待即可，最后安装完成，再次输入命令`pod --version`
通过检查版本来查看是否安装完成

## 出现zsh: command not found: xxx解决方法：

- step1: 终端执行命令`open .zshrc`
- step2: 找到`# User configuration`
- step3: 加入`source ~/.bash_profile`
- step4: 终端执行命令`source .zshrc`

## 如何处理打包的iOS文件

首先cd到工程项目文件

终端输入`cd `，然后把工程文件拖进来回车即可
然后输入命令：`Pod install --repo-update`
等待完成后，打开工程文件内xcodespace文件，然后照常进行证书添加和部署即可
