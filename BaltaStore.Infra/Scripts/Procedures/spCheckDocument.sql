CREATE DEFINER=`root`@`localhost` PROCEDURE `spCheckDocument`(in document char(11))
BEGIN
	SELECT (Id) FROM customer WHERE Document = document;
END