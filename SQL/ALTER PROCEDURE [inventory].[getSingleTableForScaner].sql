USE [dbase1]
GO
/****** Object:  StoredProcedure [inventory].[getSingleTableForScaner]    Script Date: 22.09.2020 15:17:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Create date: 2015-12-04
-- Description:	Получение основной таблицы
-- =============================================
ALTER PROCEDURE [inventory].[getSingleTableForScaner]		
	@id_kadr int = -1,
	@id_ttost int
AS
BEGIN	
	SET NOCOUNT ON;

DECLARE @dateInvent date
	select @dateInvent = dttost from dbo.j_ttost where id = @id_ttost

select 
	sb.id,
	sb.numberScaner,
	--convert(varchar(8), sb.timeStart,108) as timeStart,
	--convert(varchar(8), sb.timeEnd,108) as timeEnd,
	sb.timeStart,
	sb.timeEnd,
	case when sb.type=1 then 'Сканер' else 'Ведомость' end as typeName,
	ltrim(rtrim(p.place)) as place,
	ltrim(rtrim(d.name)) as nameDep,
	[inventory].[getNumericToDateTime](@dateInvent,s.dttost_n) as dttost_n,
	[inventory].[getNumericToDateTime](@dateInvent,s.dttost_k) as dttost_k,
	sb.id_Shop,
	sb.id_spacing
from 
	inventory.j_scanerBlank sb
		left join dbo.j_spacing s on s.id = sb.id_spacing
		left join dbo.j_tspacing ts on ts.id = s.id_spacing
		left join dbo.s_place p on p.id = ts.id_place
		left join dbo.departments d on d.id = ts.id_departments
where 
	sb.id_kadr = @id_kadr and sb.id_ttost = @id_ttost

END
