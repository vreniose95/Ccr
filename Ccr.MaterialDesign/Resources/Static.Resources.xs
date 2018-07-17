<?xml version="1.0" encoding="utf-8"?>
<xs:schema id="types"
        targetNamespace="http://ccr.org/types.xsd"
        elementFormDefault="qualified"
        xmlns="http://ccr.org/types.xsd"
        xmlns:cplx="http://www.w3.org/TR/xmlschema-2"
        xmlns:vs="http://schemas.microsoft.com/Visual-Studio-Intellisense"
        xmlns:xs="http://www.w3.org/2001/XMLSchema"
        vs:friendlyname="Ccr XSD Schema Type Declarations"
        vs:ishtmlschema="false"
        vs:iscasesensitive="false"
        vs:requireattributequotes="true">

  <xs:simpleType name="typedef_HexColorLiteral">
    <xs:restriction base="xs:string">
      <xs:pattern value="#[A-F0-9]{6}"/>
    </xs:restriction>
  </xs:simpleType>

  <xs:simpleType name="typedef_LuminosityLiteral">
    <xs:restriction base="xs:string">
      <xs:pattern value="[P|A]{1}[0-9]{3}"/>
    </xs:restriction>
  </xs:simpleType>

  <xs:complexType name="typedef_Brush">
    <xs:attribute name="Color" type="typedef_HexColorLiteral"/>
    <xs:attribute name="Luminosity" type="typedef_LuminosityLiteral"/>
  </xs:complexType>

  <!--<complexType name="typedef_BrushCollection">
    <sequence>
      <element name="Brush" type="t:typedef_Brush">
        <unique name="key_BrushColorIdentifier">
          <selector xpath="*/typedef_Brush"/>
          <field xpath="Color"/>
        </unique>
      </element>
    </sequence>
  </complexType>-->

  <xs:simpleType name="typedef_SwatchIdentifier">
    <xs:restriction base="xs:string">
      <xs:pattern value="[A-Z]{1}[A-z ]*"/>
    </xs:restriction>
  </xs:simpleType>

  <xs:complexType name="typedef_Swatch">
    <xs:sequence>
      <xs:element name="Brush" type="typedef_Brush"
                  minOccurs="0" maxOccurs="unbounded">
        <xs:unique name="key_BrushColorIdentifier">
          <xs:selector xpath="*/typedef_Brush"/>
          <xs:field xpath="Color"/>
        </xs:unique>
      </xs:element>
    </xs:sequence>
    <xs:attribute name="SwatchIdentifier" type="typedef_SwatchIdentifier"/>
  </xs:complexType>

  <!--<xs:complexType name="typedef_SwatchCollection">
    <xs:sequence>
      <xs:element name="Swatch" type="typedef_Swatch"
                  minOccurs="0" maxOccurs="unbounded">
        <xs:unique name="key_SwatchIdentifierIdentifier">
          <xs:selector xpath="*/typedef_Swatch"/>
          <xs:field xpath="SwatchIdentifier"/>
        </xs:unique>
      </xs:element>
    </xs:sequence>
  </xs:complexType>-->

  <xs:complexType name="typedef_Abstract_MDH_Classification"
                  abstract="true">

  </xs:complexType>

  <xs:complexType name="typedef_Palette">
    <xs:sequence>
      <xs:element name="Swatch" type="typedef_Swatch"
                  minOccurs="0" maxOccurs="unbounded">
        <xs:unique name="key_SwatchIdentifierIdentifier">
          <xs:selector xpath="*/typedef_Swatch"/>
          <xs:field xpath="SwatchIdentifier"/>
        </xs:unique>
      </xs:element>
    </xs:sequence>
    <!--<xs:complexContent>
      <xs:extension base="typedef_Abstract_MDH_Classification">
        <xs:sequence>
          <xs:element name="SwatchCollection" 
                      type="typedef_SwatchCollection"
                      minOccurs="0" maxOccurs="unbounded">

          </xs:element>
        </xs:sequence>
      </xs:extension>
    </xs:complexContent>-->
  </xs:complexType>

  <xs:complexType name="typedef_MDH">
    <xs:choice>
      <xs:element name="MDH_Subclassification" 
                  type="typedef_Abstract_MDH_Classification"/>
      <xs:element name="Palette" type="typedef_Palette"/>
    </xs:choice>
  </xs:complexType>

  <!--<xs:element name="Palette" type="typedef_Palette">

  </xs:element>-->

  <xs:element name="MDH" type="typedef_MDH">

  </xs:element>


</xs:schema>
