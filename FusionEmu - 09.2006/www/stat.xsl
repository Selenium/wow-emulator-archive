<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" indent="yes"/>
<xsl:template match="/">

<html>
<head>

<meta http-equiv="Pragma" content="no-cache"/>
<meta http-equiv="Cache-Control" content="no-cache"/>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1251"/>
<meta http-equiv="content-language" content="en"/>
<title>Server Fusion :: Stats</title>
<style type="text/css" media="screen">@import url(css/stats.css);</style>
</head>
<body bgcolor="#000000" text="#CCCCCC" link="#FFFFFF" background="">
<xsl:apply-templates/>

</body>
</html>
 </xsl:template>
  <xsl:template match="server">
    <br />
	<table width="500px" align="center" id="serverinfo" >
    <tr>
      <td width="25%" class="statstdtop">Version</td>
      <td width="25%" class="statstdtop">Owner</td>
      <td width="25%" class="statstdtop">Server Name</td>
      <td width="25%" class="statstdtop">Uptime</td>
     </tr>
      <xsl:apply-templates/>
	</table>
 </xsl:template>
  <xsl:template match="version">
    <td class="statstd">
      <xsl:apply-templates/>
    </td>
  </xsl:template>
  <xsl:template match="owner">
    <td class="statstd">
      <xsl:apply-templates/>
    </td>
  </xsl:template>
  <xsl:template match="servername">
    <td class="statstd">
      <xsl:apply-templates/>
    </td>
  </xsl:template>
  <xsl:template match="uptime">
    <td class="statstd">
      <xsl:apply-templates/>
    </td>
  </xsl:template>

  <xsl:template match="serverload">
    <br />
	<table width="500px" align="center" id="serverstats" >
    <tr>
      <td width="20%" class="statstdtop">Server Stats</td>
      <td width="20%" class="statstdtop">Timing</td>
      <td width="20%" class="statstdtop">Loops</td>
      <td width="20%" class="statstdtop">Total Time</td>
      <td width="20%" class="statstdtop">Load</td>
    </tr>
      <xsl:apply-templates/>
  	</table>
   	<table class="refresh" align="center">
	<td><a href="stat.xml" target="_self">Refresh</a></td>
	</table>


 </xsl:template>


  <xsl:template match="world">
    <tr class="plist">
     <td width="20%" class="statstd">World</td>
      <xsl:apply-templates/>
    </tr>
  </xsl:template>

  <xsl:template match="network">
    <tr class="plist">
     <td width="20%" class="statstd">Network</td>
      <xsl:apply-templates/>
    </tr>
  </xsl:template>

  <xsl:template match="configsleep">
    <td class="statstd">
      <xsl:apply-templates/>
    </td>
  </xsl:template>

  <xsl:template match="loops">
    <td class="statstd">
      <xsl:apply-templates/>
    </td>
  </xsl:template>

  <xsl:template match="totaltime">
    <td class="statstd">
      <xsl:apply-templates/>
    </td>
  </xsl:template>

  <xsl:template match="load">
    <td class="statstd">
      <xsl:apply-templates/>
    </td>
  </xsl:template>

  <xsl:template match="players">
      <div class="center">
      <p class="text"><span class="stat"><xsl:value-of select="count(./*)"/></span> players online.</p>
      </div>
  <table align="center" id="playerlist">
     <tr class="plist">
  	<td width="80px" align="center" class="statstdtop">Level</td>
  	<td width="80px" align="center" class="statstdtop">Name</td>
  	<td width="60px" align="center" class="statstdtop">Race</td>
  	<td width="80px" align="center" class="statstdtop">Class</td>
  	<td width="80px" align="center" class="statstdtop">Location</td>
  	<td width="80px" align="center" class="statstdtop">Zone</td>
  	<td width="80px" align="center" class="statstdtop">Ping</td>
  	<td width="80px" align="center" class="statstdtop">P-Level</td>

     </tr>

      <xsl:for-each select="player">

	  <xsl:sort select="level" data-type="number" />
      <tr>

         <td class="l3v3l">
			<div>
            <xsl:attribute name="class">
               <xsl:choose>
               <xsl:when test="level &lt; 10">white</xsl:when>
               <xsl:when test="level &lt; 20">low</xsl:when>
               <xsl:when test="level &lt; 30">low-mid</xsl:when>
               <xsl:when test="level &lt; 40">mid</xsl:when>
               <xsl:when test="level &lt; 56">high</xsl:when>
               <xsl:when test="level &gt; 55">high-blink</xsl:when>
               </xsl:choose>

            </xsl:attribute>
            <xsl:value-of select="level" />
            </div>
	     </td>

         <td class="n4m3">
            <div>
            <xsl:attribute name="class">
			   <xsl:choose>
               <xsl:when test="race = 1">alliance</xsl:when>
               <xsl:when test="race = 3">alliance</xsl:when>
               <xsl:when test="race = 4">alliance</xsl:when>
			   <xsl:when test="race = 7">alliance</xsl:when>
			   <!--  -->
               <xsl:when test="race = 2">horde</xsl:when>
	           <xsl:when test="race = 5">horde</xsl:when>
               <xsl:when test="race = 6">horde</xsl:when>
               <xsl:when test="race = 8">horde</xsl:when>
               </xsl:choose>

            </xsl:attribute>
			<xsl:value-of select="name" />
            </div>
         </td>

         <td class="r4c3">
	       <div>
            <xsl:attribute name="class">
	       <xsl:choose>
               <xsl:when test="race = 1">Human</xsl:when>
               <xsl:when test="race = 2">Orc</xsl:when>
               <xsl:when test="race = 3">Dwarf</xsl:when>
               <xsl:when test="race = 4">NightElf</xsl:when>
               <xsl:when test="race = 5">Undead</xsl:when>
               <xsl:when test="race = 6">Tauren</xsl:when>
               <xsl:when test="race = 7">Gnome</xsl:when>
               <xsl:when test="race = 8">Troll</xsl:when>
               </xsl:choose>

            </xsl:attribute>
<br />
<br />
	       <xsl:choose>
               <xsl:when test="race = 1">Human</xsl:when>
               <xsl:when test="race = 2">Orc</xsl:when>
               <xsl:when test="race = 3">Dwarf</xsl:when>
               <xsl:when test="race = 4">NightElf</xsl:when>
               <xsl:when test="race = 5">Undead</xsl:when>
               <xsl:when test="race = 6">Tauren</xsl:when>
               <xsl:when test="race = 7">Gnome</xsl:when>
               <xsl:when test="race = 8">Troll</xsl:when>
               </xsl:choose>
<br />
            </div>
         </td>


         <td class="cl4ss">
	    <div>
            <xsl:attribute name="class">
	       <xsl:choose>
               <xsl:when test="class = 1">Warrior</xsl:when>
               <xsl:when test="class = 2">Paladin</xsl:when>
               <xsl:when test="class = 3">Hunter</xsl:when>
               <xsl:when test="class = 4">Rogue</xsl:when>
               <xsl:when test="class = 5">Priest</xsl:when>
               <xsl:when test="class = 6">FUTURE_1</xsl:when>
               <xsl:when test="class = 7">Shaman</xsl:when>
               <xsl:when test="class = 8">Mage</xsl:when>
               <xsl:when test="class = 9">Warlock</xsl:when>
               <xsl:when test="class = 10">FUTURE_2</xsl:when>
               <xsl:when test="class = 11">Druid</xsl:when>
            </xsl:choose>

            </xsl:attribute>
<br />
<br />
               <xsl:choose>
               <xsl:when test="class = 1">Warrior</xsl:when>
               <xsl:when test="class = 2">Paladin</xsl:when>
               <xsl:when test="class = 3">Hunter</xsl:when>
               <xsl:when test="class = 4">Rogue</xsl:when>
               <xsl:when test="class = 5">Priest</xsl:when>
               <xsl:when test="class = 6">FUTURE_1</xsl:when>
               <xsl:when test="class = 7">Shaman</xsl:when>
               <xsl:when test="class = 8">Mage</xsl:when>
               <xsl:when test="class = 9">Warlock</xsl:when>
               <xsl:when test="class = 10">FUTURE_2</xsl:when>
               <xsl:when test="class = 11">Druid</xsl:when>
               </xsl:choose>
<br />
            </div>
         </td>


         <td class="m4p">
			<xsl:choose>
			<xsl:when test="map = 0">Azeroth</xsl:when>
			<xsl:when test="map = 1">Kalimdor</xsl:when>
			<xsl:when test="map = 13">test</xsl:when>
			<xsl:when test="map = 25">Scott Test</xsl:when>
			<xsl:when test="map = 29">Cash Test</xsl:when>
			<xsl:when test="map = 30">PVP Zone 01</xsl:when>
			<xsl:when test="map = 33">Shadowfang</xsl:when>
			<xsl:when test="map = 34">Stormwind Jail</xsl:when>
			<xsl:when test="map = 35">Stormwind Prizon</xsl:when>
			<xsl:when test="map = 36">Deadmines Instance</xsl:when>
			<xsl:when test="map = 37">PVP Zone 02</xsl:when>
			<xsl:when test="map = 42">Collin's Test</xsl:when>
			<xsl:when test="map = 43">Wailing Caverns Instance</xsl:when>
			<xsl:when test="map = 44">Monastery Interior</xsl:when>
			<xsl:when test="map = 47">Razorfen Kraul Instance</xsl:when>
			<xsl:when test="map = 48">Blackfathom Instance</xsl:when>
			<xsl:when test="map = 70">Uldaman Instance</xsl:when>
			<xsl:when test="map = 90">Gnomeragon Instance</xsl:when>
			<xsl:when test="map = 109">Sunken Temple Instance</xsl:when>
			<xsl:when test="map = 129">Razorfen Downs Instance</xsl:when>
			<xsl:when test="map = 169">Emerald Dream</xsl:when>
			<xsl:when test="map = 189">Monastery Instances</xsl:when>
			<xsl:when test="map = 209">Zul'farrak</xsl:when>
			<xsl:when test="map = 229">Blackrock Upper Instance</xsl:when>
			<xsl:when test="map = 230">Blackrock Lower Instance</xsl:when>
			<xsl:when test="map = 249">Onyxias Lair Instance</xsl:when>
			<xsl:when test="map = 269">Caverns of Time</xsl:when>
			<xsl:when test="map = 289">School of Necromancy</xsl:when>
			<xsl:when test="map = 309">Zul'gurub</xsl:when>
			<xsl:when test="map = 329">Stratholme</xsl:when>
			<xsl:when test="map = 369">Deeprun Tram</xsl:when>
			<xsl:when test="map = 389">Orgrimmar Instance</xsl:when>
			<xsl:when test="map = 349">Mauradon</xsl:when>
			<xsl:when test="map = 409">Molten Core</xsl:when>
			<xsl:when test="map = 429">Dire Maul</xsl:when>
			<xsl:when test="map = 449">Alliance PVP Barracks</xsl:when>
			<xsl:when test="map = 450">Horde PVP Barracks</xsl:when>
			<xsl:when test="map = 451">Development Land</xsl:when>
			<xsl:when test="map = 469">Blackwing Lair</xsl:when>
            </xsl:choose>
         </td>


         <td class="z0n3">
			<xsl:choose>
			<xsl:when test="zone = 406">Stonetalon Mountains</xsl:when>
			<xsl:when test="zone = 15">Dustwallow</xsl:when>
			<xsl:when test="zone = 1377">Silithus</xsl:when>
			<xsl:when test="zone = 1519">Stormwind</xsl:when>
			<xsl:when test="zone = 1637">Ogrimmar</xsl:when>
			<xsl:when test="zone = 1497">Undercity</xsl:when>
			<xsl:when test="zone = 2597">Alterac Valley</xsl:when>
			<xsl:when test="zone = 357">Feralas</xsl:when>
			<xsl:when test="zone = 440">Tanaris</xsl:when>
			<xsl:when test="zone = 14">Durotar</xsl:when>
			<xsl:when test="zone = 215">Mulgore</xsl:when>
			<xsl:when test="zone = 17">Barrens</xsl:when>
			<xsl:when test="zone = 36">Alterac Mountains</xsl:when>
			<xsl:when test="zone = 45">Arathi</xsl:when>
			<xsl:when test="zone = 3">Badlands</xsl:when>
			<xsl:when test="zone = 4">Blasted Lands</xsl:when>
			<xsl:when test="zone = 85">Tirisfal</xsl:when>
			<xsl:when test="zone = 130">Silverpine</xsl:when>
			<xsl:when test="zone = 28">Western Plaguelands</xsl:when>
			<xsl:when test="zone = 139">Eastern Plaguelands</xsl:when>
			<xsl:when test="zone = 267">Hilsbrad</xsl:when>
			<xsl:when test="zone = 47">Hinterlands</xsl:when>
			<xsl:when test="zone = 1">Dun Morogh</xsl:when>
			<xsl:when test="zone = 51">Searing Gorge</xsl:when>
			<xsl:when test="zone = 46">Burning Steppes</xsl:when>
			<xsl:when test="zone = 12">Elwynn Forest</xsl:when>
			<xsl:when test="zone = 41">Deadwind Pass</xsl:when>
			<xsl:when test="zone = 10">Duskwood</xsl:when>
			<xsl:when test="zone = 38">Loch Modan</xsl:when>
			<xsl:when test="zone = 44">Redridge</xsl:when>
			<xsl:when test="zone = 33">Stranglethorn</xsl:when>
			<xsl:when test="zone = 8">Swamp Of Sorrows</xsl:when>
			<xsl:when test="zone = 40">Westfall</xsl:when>
			<xsl:when test="zone = 11">Wetlands</xsl:when>
			<xsl:when test="zone = 141">Teldrassil</xsl:when>
			<xsl:when test="zone = 148">Darkshore</xsl:when>
			<xsl:when test="zone = 331">Ashenvale</xsl:when>
			<xsl:when test="zone = 405">Desolace</xsl:when>
			<xsl:when test="zone = 400">Thousand Needles</xsl:when>
			<xsl:when test="zone = 16">Aszhara</xsl:when>
			<xsl:when test="zone = 361">Felwood</xsl:when>
			<xsl:when test="zone = 618">Winterspring</xsl:when>
			<xsl:when test="zone = 1537">Ironforge</xsl:when>
			<xsl:when test="zone = 1657">Darnassus</xsl:when>
			<xsl:when test="zone = 490">Ungoro Crater</xsl:when>
			<xsl:when test="zone = 493">Moonglade</xsl:when>
			<xsl:when test="zone = 719">Dungeon</xsl:when>
			<xsl:when test="zone = 1638">Thunder Bluff</xsl:when>
			<xsl:when test="zone = 2100">The Wicked Grotto</xsl:when>
            </xsl:choose>
         </td>


         <td class="p1ng">
            <div>
            <xsl:attribute name="class">
               <xsl:choose>
               <xsl:when test="ping &lt; 99">low</xsl:when>
               <xsl:when test="ping &lt; 199">mid</xsl:when>
               <xsl:when test="ping &gt; 199">high</xsl:when>
               </xsl:choose>

            </xsl:attribute>
            <xsl:value-of select="ping" />
            </div>
	     </td>


         <td class="p13v31">
		 <!-- plevel -->
			<div>

            <xsl:attribute name="class">
               <xsl:choose>
               <xsl:when test="plevel = 0">Player</xsl:when>
               <xsl:when test="plevel = 1">Counselor</xsl:when>
               <xsl:when test="plevel = 2">Seer</xsl:when>
               <xsl:when test="plevel = 3">Moderator</xsl:when>
               <xsl:when test="plevel = 4">GM</xsl:when>
               <xsl:when test="plevel = 5">Administrator</xsl:when>
	           <xsl:when test="plevel &gt; 5">Developer</xsl:when>
               </xsl:choose>
            </xsl:attribute>
            <!--<xsl:value-of select="plevel" /><br />-->
               <xsl:choose>
               <xsl:when test="plevel = 0">Player</xsl:when>
               <xsl:when test="plevel = 1">Counselor</xsl:when>
               <xsl:when test="plevel = 2">Seer</xsl:when>
               <xsl:when test="plevel = 3">Moderator</xsl:when>
               <xsl:when test="plevel = 4">GM</xsl:when>
               <xsl:when test="plevel = 5">Administrator</xsl:when>
	           <xsl:when test="plevel &gt; 5">Developer</xsl:when>
               </xsl:choose>

            </div>
	     </td>



      </tr>
      </xsl:for-each>
</table>

   </xsl:template>

</xsl:stylesheet>