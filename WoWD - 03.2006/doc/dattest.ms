utility dattest "WoW terrain ADT Importer"
(
	----------
	-- Vars --
	----------
	local modelName

	local impTypes

	local seqs			-- Sequences
	local mtls			-- Materials
	local geos			-- Geometry
	local objs			-- Bones, Helpers, Lights, Attachments
	local pivot

	local geobones

	local notes			-- Note Track
	
	local meshes = #()
	----------------
	-- Structures --
	----------------
	struct File
	(
		pos, end, bstream,

		-- Helper function to init the top-level chunk rover
		fn Init stream=
		(
			bstream = stream
			pos = ftell bstream
			fseek bstream 0 #seek_end
			end = ftell bstream
		),

		fn fReadHead=
		(
			fseek bstream pos #seek_set
			local id = ReadLong bstream #unsigned
			local tag = File.GetName id
			pos += 4
			tag
		),

		fn fReadFloat=
		(
			local id
			local i = 0
			while (id == undefined) and (i < 10) do
			(
				fseek bstream pos #seek_set
				id = ReadFloat bstream
				i += 1
			)
			if i == 10 then
			(
				print ("problem: " + (pos as string))
			)
			pos += 4
			id
		),

		fn fReadLong=
		(
			fseek bstream pos #seek_set
			local id = ReadLong bstream
			pos += 4
			id
		),

		fn fReadShort=
		(
			fseek bstream pos #seek_set
			local id = ReadShort bstream
			pos += 2
			id
		),

		fn fReadByte=
		(
			fseek bstream pos #seek_set
			local id = ReadByte bstream
			pos += 1
			id
		),

		fn fReadString n=
		(
			fseek bstream pos #seek_set
			local id = ReadString bstream
			pos += n*80
			id
		)
	)


	--------------------
	-- User Interface --
	--------------------
	group "Import ADT"
	(
		button importButton "Import ADT..."
	)

	--------------------------
	-- Main Import Function --
	--------------------------

	on importButton pressed do
	(
		-- Show open file dialog box
		local objFileName = getOpenFileName caption:"Import ADT" types:"WoW terrain File (*.adt)|*.adt|All Files (*.*)|*.*|"


		local isValid = true
		if objFileName != undefined then
		(
			-- If user made a selection, begin importing
			if doesFileExist objFileName then
			(
				-- Open up the file as a binary stream
				local bstream = fopen objFileName "rb"			
				local mdx = File()
				local chunkoff = #()
				local mapoff = #()
				local refx = #()
				local refy = #()
				local refz = #()
				mdx.Init bstream
				mdx.pos += 92
				for m = 1 to m = 256 do
				(
					chunkoff[m] = mdx.fReadLong()
					mdx.pos += 12
				)
				for m = 1 to m = 256 do
				(
					mdx.pos = chunkoff[m]
					--messagebox ("reading main chunk at" + (mdx.pos as string))
					mdx.pos += 112
					--messagebox ("reading float offsets at " + (mdx.pos as string))
					refy[m] = mdx.fReadFloat()
					refx[m] = -(mdx.fReadFloat())
					refz[m] = mdx.fReadFloat()
					mapoff[m] = mdx.pos + 20
				)
				local test = #()				
				local verts = #()
				local x
				local y
				local z
				count = 1
				for w = 1 to w = 256 do
				(
					mdx.pos = mapoff[w]				
					--messagebox ("reading height data at " + (mdx.pos as string))
					for n = 1 to n = 9 do
					(
						for m = 1 to m = 9 do
						(
							x = refx[w] + ((m - 1) * (33.334 / 8))
							y = (refy[w] - ((n - 1) * (33.334 / 8)))
							z = refz[w] + mdx.fReadFloat()
							verts[count] = point3 x y z
							count += 1
						)
						mdx.pos += 32
					)
				)
				test[1] = mesh numverts: verts.count numfaces: 0
				for b = 1 to b = verts.count do
				(
					test[1].vertices[b] = verts[b]
				)
				p = convertToPoly(test[1])
				for v = 1 to v = 50 do
				(
					for m = 1 to m = 8 do
					(
						for n = 1 to n = 8 do
						(
							local e = (((m - 1) * 9) + n) + ((v - 1) * 81)
							local f = (((m - 1) * 9) + n) + 1 + ((v - 1) * 81)
							local g = ((((m) * 9) + n)) + ((v - 1) * 81)
							local h = ((((m) * 9) + n) + 1) + ((v - 1) * 81)
							p.createFace #(e,f,h,g)		
						)
					)
				)
				messagebox "completed!"
			)	
		)
	)
)

--getNodeByName <string> exact:<boolean>