USE MASTER;
USE MyDatabase;

--1
--Получить имена покупателей,
-- с числом детей более 1 старше 1990 года рождения или 
--младше 1990 года рождения
SELECT FirstName, MiddleName, LastName 
FROM DimCustomer 
WHERE TotalChildren > 1 AND
 BirthDate BETWEEN  '19700101'  AND '19900101';
GO

--2
--Получить наименование категории товаров, из которых
-- покупали товары с 10 по 20 авг 2007 г покупатели из Германии
SELECT ProductKey 
FROM FactInternetSales
WHERE OrderDate BETWEEN '20070601' AND '20070831' AND SalesTerritoryKey
				 IN(SELECT SalesTerritoryKey FROM DimSalesTerritory
					WHERE SalesTerritoryCountry = 'Germany');
GO

--3
--Получить имя 3 по числу заказов покупателя, 
--который заказывал товары из категории "Clothing" 
SELECT 



--4
--для каждого товара получить страну, в котррую чаще всего отпр среди тех заказов,
--в которых макс число продукт больше 5
SELECT SalesTerritoryCountry FROM DimSalesTerritory
WHERE SalesTerritoryKey 
	IN(SELECT SalesTerritoryKey 
	FROM FactInternetSales
	WHERE (MAX(OrderQuantity)>5));
							
		
--5
--Имена покупателей, котрые ни разу не делали заказ,
-- в котором было 2 товара в кол-ве более 3 шт
SELECT FirstName, MiddleName, LastName 
FROM DimCustomer 
WHERE CustomerKey IN(SELECT CustomerKey FROM FactInternetSales
						WHERE OrderQuantity > 3 );


--6
SELECT DISTINCT CustomerKey, PromotionKey FROM FactInternetSales INNER JOIN 

--7
-- 



