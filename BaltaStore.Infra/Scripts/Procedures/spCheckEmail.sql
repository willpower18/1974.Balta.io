CREATE DEFINER=`root`@`localhost` PROCEDURE `spCheckEmail`(IN email varchar(160))
BEGIN
	SELECT (Id) FROM customer WHERE Email = email;
END