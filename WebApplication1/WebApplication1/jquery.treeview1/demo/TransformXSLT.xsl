<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" encoding="utf-8"/>
  <!-- Find the root node called Menus 
       and call MenuListing for its children -->
  <xsl:template match="/SiteItems">
    <MenuItems>
      <xsl:call-template name="MenuListing" />
    </MenuItems>
  </xsl:template>
  
  <!-- Allow for recusive child node processing -->
  <xsl:template name="MenuListing">
    <xsl:apply-templates select="SiteItem" />
  </xsl:template>
  
  <xsl:template match="SiteItem">
    <MenuItem>
      <!-- Convert Menu child elements to MenuItem attributes -->
      <xsl:attribute name="bsi_item_id">
        <xsl:value-of select="Text"/>
      </xsl:attribute>
      <xsl:attribute name="bsi_title">
        <xsl:value-of select="Description"/>
      </xsl:attribute>
      <xsl:attribute name="bsi_bfw_uid">
        <xsl:text>?Sel=</xsl:text>
        <xsl:value-of select="Text"/>
      </xsl:attribute>
      
      <!-- Call MenuListing if there are child Menu nodes -->
      <xsl:if test="count(SiteItem) > 0">
        <xsl:call-template name="MenuListing" />
      </xsl:if>
    </MenuItem>
  </xsl:template>
</xsl:stylesheet>
