ALTER TABLE [dbo].[NinjaEquipment]
	ADD CONSTRAINT [ForeignKeyConstraint2]
	FOREIGN KEY (EquipmentName)
	REFERENCES [Equipment] (Name)
