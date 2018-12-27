select file_.name from file_ inner join catalog_ on file_.id_catalog = Catalog_.ID
where Catalog_.name = "Bin64";