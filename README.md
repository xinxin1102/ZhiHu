
# ZhiHu
知乎爬虫
这个爬虫动用实验室十台电脑一起干活，为了能够实现断点续爬和多台电脑之间的协作使用了Redis作队列，为了保证不重复爬取使用Redis作hash表,所有爬取的任务都放到hash表中进行标记。爬取太频繁会被知乎返回429（too many request）,应对的策略是挂代理，一种方法是使用专业的云代理服务（有点贵）,另外一种自建代理池（https://github.com/wangqifan/ProxyPool ），定时爬取互联网上免费代理ip。最后数据使用sql server存储，最后对数据进行分析，使用百度的echart.js进行画图

抓取百万知乎用户数据之爬取思路 http://www.cnblogs.com/zuin/p/6227834.html 

抓取百万知乎用户设计之实体设计 http://www.cnblogs.com/zuin/p/6227934.html 

抓取百万知乎用户信息之HttpHelper的迭代 http://www.cnblogs.com/zuin/p/6257125.html 

抓取知乎百万用户信息之自建代理池 http://www.cnblogs.com/zuin/p/6261677.html

抓取知乎百万用户信息之Redis篇 http://www.cnblogs.com/zuin/p/6261709.html 

抓取知乎百万用户信息之爬虫模块 http://www.cnblogs.com/zuin/p/6261745.html  

抓取知乎百万用户信息之总结篇 http://www.cnblogs.com/zuin/p/6261772.html        
  如果想运行程序，请装好Redis，sqlserver 配置好Redis，配置好连接字符
