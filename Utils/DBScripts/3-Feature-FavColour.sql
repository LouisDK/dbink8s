ALTER TABLE People
ADD favColour nvarchar(50) NOT NULL DEFAULT('Red');

UPDATE People
	SET favColour = 'Navy Blue'
WHERE personID = 1;
