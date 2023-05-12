با این وب سرویس شما میتوانید از endpoint عمومی سایت طاقچه با دادن شناسه کتاب ، اطلاعات مربوط به آن را دریافت کنید. اگر شناسه اشتیاه بود یا کتابی با آن شناسه پیدا نشد ، پیام "Book not  found" به همراه Http Response Code مناسب دربافت خواهید کرد.endpoint مربوط به سایت طاقچه در فایل کانفیگ قابل تنظیم است.(BaseUrl,ApiVersion,Endpoint)
سرویس مورد نظر با دریافت request ، ابتدا در InMemory Query به دنبال کتاب مورد نظر خواهد گشت در صورت یافتن کتاب آن را بر مگرداند در غیراین صورت در سطح بعدی (یعنی Distributed Cache ؛ که با استفاده از redis پیاده سازی شده است)به دنبال کتاب میگردد اگر پیدا شد ، ابتدا آن را به InMemory اضافه میکند و بعد برمیگرداند ؛ اگر در این لایه هم نبود به Api طاقچه درخواست ارسال میکند و در صورتی که جواب معتبر دریافت کند آن را در هر دو لابه کش اضافه میکند. برای پیاده سازی سیاست caching و اولویت های آنها از chain of responsibility استفاده شده که به ما اجازه میدهد تا به راحتی لایه های دیگری اضافه کنیم یا اولویت ها را تغییر بدهیم
معماری برنامه Hexagonal است بنابراین dependency های خارجی به صورت Adaptor هایی تعریف شده اند که می توانند به Port ها plug-in بشوند. بنابراین برای تغییر هر adaptor کافیه پیاده سازی جدید، interface مربوط به port مورد نظر را رعایت کند تا براحتی آن را جایگزین کنیم
