/****** Object:  Table [dbo].[Reviews]    Script Date: 04/09/2019 16:20:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ID] [varchar](50) NOT NULL,
	[ProductID] [char](10) NOT NULL,
	[ProductBrand] [nvarchar](100) NOT NULL,
	[ProductReviews] [int] NOT NULL,
	[Language] [varchar](5) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Author] [nvarchar](100) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Rating] [tinyint] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Reviews] ([ID], [ProductID], [ProductBrand], [ProductReviews], [Language], [Title], [Author], [Body], [Rating]) VALUES (N'R10081R3BVFX15', N'B00BIJRABY', N'DeLonghi', 34, N'IT', N'Perde acqua in abbondanza', N'', N'Articolo PRO1465. Potrebbe essere un lotto difettoso visto che ho trovato altre recensioni con lo stesso problema. Per evitare la perdita di acqua l''assistenza &#34;Emmeci service&#34; ci ha consigliato di mantenere la manopola del vapore al massimo. Risultato? Un indesiderato getto di vapore continuo e impossibilitÃ  di fare delle regolazioni sul vapore. Restituito immediatamente!', 1)
GO
INSERT [dbo].[Reviews] ([ID], [ProductID], [ProductBrand], [ProductReviews], [Language], [Title], [Author], [Body], [Rating]) VALUES (N'R100BO0TKTWXIQ', N'B00D3HV31M', N'Bionike', 68, N'IT', N'Non li ricomprerÃ²', N'', N'Molto fresco poco dopo l''applicazione. Buona assorbenza. Ma non ho visto nessun effetto drenante anche associato ad un massaggio fatto con un robottino vibrante. Quindi non mantiene quel che promette per gli inestetismi della pelle. Non Ã¨ nemmeno particolarmente idratante.', 2)
GO
INSERT [dbo].[Reviews] ([ID], [ProductID], [ProductBrand], [ProductReviews], [Language], [Title], [Author], [Body], [Rating]) VALUES (N'R100EA4LHPW1WV', N'B01J5FGW66', N'Philips', 170, N'IT', N'Il ferro da stiro magico, che trasforma la tortura in un piacere!!!', N'', N'Devo confessare che non mi piace molto stirare, ma con questo ferro da stiro mi sono trovata a meraviglia. E'' semplice da usare, leggero, silenzioso e efficace. Non serve scegliere la temperatura adatta, ci pensa a tutto lui. Non lascia la stoffa lucida e non c''Ã¨ rischio di bruciare i capi. Con l''uso di acqua del rubinetto non devo piÃ¹ comprare l''acqua per stirare, Ã¨ un bel risparmio. Con la modalitÃ  ECO mi fa anche risparmiare l''energia elettrica. Sono molto soddisfatta!', 5)
GO
INSERT [dbo].[Reviews] ([ID], [ProductID], [ProductBrand], [ProductReviews], [Language], [Title], [Author], [Body], [Rating]) VALUES (N'R100EVNZTF0MS3', N'B008VO7MXU', N'Polti', 136, N'IT', N'Ottima, serbatoio troppo piccolo', N'', N'Ottima, presa con un offerta lampo fa egregiamente il suo lavoro. Non avendo un sistema vero e proprio di anti calcare bisogna usare un mix di acqua di rubinetto e demineralizzata in alcune cittÃ  come da istruzioni. Unica pecca serbatio piccolissimo.', 4)
GO
INSERT [dbo].[Reviews] ([ID], [ProductID], [ProductBrand], [ProductReviews], [Language], [Title], [Author], [Body], [Rating]) VALUES (N'R100HKMWHA4Q3A', N'B00B4S5VWE', N'Rowenta', 170, N'IT', N'Funziona perfettamente', N'', N'Pure Io riesco a stirare la camice con facilitÃ', 5)
GO
INSERT [dbo].[Reviews] ([ID], [ProductID], [ProductBrand], [ProductReviews], [Language], [Title], [Author], [Body], [Rating]) VALUES (N'R100IOHKNQF4P0', N'B00O0W6SQE', N'Chicco', 170, N'IT', N'Perfecto para mucho tiempo', N'', N'Lo compre para usarlo en el coche de la empresa, necesitaba una silleta que no tenga que cambiar cada aÃ±o y esta es perfecta. Buena calidad y buen precio.', 5)
GO
INSERT [dbo].[Reviews] ([ID], [ProductID], [ProductBrand], [ProductReviews], [Language], [Title], [Author], [Body], [Rating]) VALUES (N'R100O5VL38YALX', N'B01BMDWBLY', N'Goleador', 170, N'IT', N'.', N'', N'Muuu buonissime', 5)
GO
INSERT [dbo].[Reviews] ([ID], [ProductID], [ProductBrand], [ProductReviews], [Language], [Title], [Author], [Body], [Rating]) VALUES (N'R100QRIVL115VK', N'B07D8WGNWP', N'RIMMEL', 170, N'IT', N'Ottimo mascara volumizzante', N'', N'Il mascara Rimmel ScandalEyes Wow Wings si applica prima con il lato alato (lungo da un lato e corto dall''altro) per posizionare il prodotto sulle ciglia e poi con l''altro lato dell''applicatore, curvo, si separano le ciglia e si rimuovono o comunque stendono eventuali depositi di mascara.

Il mascara dona effettivamente piÃ¹ volume e lunghezza alle ciglia e c''Ã¨ abbastanza effetto "wow". Quindi nulla da dire sugli effetti, ci sono.
L''applicazione Ã¨ semplice, ricordando di usare i due lati dell''applicatore nel giusto ordine, e ricordando che comunque un mascara deve essere denso per rimanere attaccato alle ciglia e che Ã¨ quindi necessario spalmarlo bene per renderlo uniforme.

Il tubetto ha una capacitÃ  di 12 ml e costa attualmente poco meno di 10 euro; il prezzo Ã¨ quindi nella media e il rapporto qualitÃ /prezzo del prodotto Ã¨ molto buono. Ãˆ piaciuto molto a mia sorella, che lo ha provato.', 5)
GO
INSERT [dbo].[Reviews] ([ID], [ProductID], [ProductBrand], [ProductReviews], [Language], [Title], [Author], [Body], [Rating]) VALUES (N'R100Y2U3OLRWUC', N'B00B4S5VWE', N'Rowenta', 170, N'IT', N'buon prodotto', N'', N'riporto le impressioni di mia moglie...il prodotto Ã¨ ben fatto e soprattutto facile e leggero da usare. Arriva a temperatura in pochissimi minuti e stira bene.', 5)
GO
INSERT [dbo].[Reviews] ([ID], [ProductID], [ProductBrand], [ProductReviews], [Language], [Title], [Author], [Body], [Rating]) VALUES (N'R1012I1J6TOCJI', N'B013K5F3HQ', N'Philips', 170, N'IT', N'Ferro che nn si regola', N'', N'Ero un po scettica...ma ho fatto il giusto acquisto stira bene e leggero e veloce...unica pecca ogni tanto fa un po di rumore quando ricarica il vapore', 5)
GO
