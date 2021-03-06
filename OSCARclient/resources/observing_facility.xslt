﻿<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <wmdr:WIGOSMetadataRecord xmlns:wmdr="http://def.wmo.int/wmdr/2017" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:gmd="http://www.isotc211.org/2005/gmd" xmlns:gco="http://www.isotc211.org/2005/gco" xmlns:om="http://www.opengis.net/om/2.0" xmlns:gml="http://www.opengis.net/gml/3.2" xmlns:sam="http://www.opengis.net/sampling/2.0" xmlns:sams="http://www.opengis.net/samplingSpatial/2.0" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" gml:id="id1" xsi:schemaLocation="http://def.wmo.int/wmdr/2017 http://schemas.wmo.int/wmdr/1.0RC8/wmdr.xsd">
      <wmdr:headerInformation owns="false">
        <wmdr:Header/>
      </wmdr:headerInformation>
      <wmdr:facility>
        <wmdr:ObservingFacility gml:id="_{station/wigosid/text()}">
          <gml:identifier codeSpace="http://wigos.wmo.int">
            <xsl:value-of select="station/wigosid/text()"/>
          </gml:identifier>
          <gml:name>
            <xsl:value-of select="station/name/text()"/>
          </gml:name>
          <wmdr:responsibleParty>
            <wmdr:ResponsibleParty>
              <wmdr:responsibleParty>
                <gmd:CI_ResponsibleParty>
                  <gmd:role>
                    <gmd:CI_RoleCode codeList="http://www.isotc211.org/2005/resources/Codelist/gmxCodelists#CI_RoleCode" codeListValue="pointOfContact"/>
                  </gmd:role>
                </gmd:CI_ResponsibleParty>
              </wmdr:responsibleParty>
              <wmdr:validPeriod>
                <gml:TimePeriod gml:id="tp_party_1">
                  <gml:beginPosition>
                    <xsl:value-of select="station/dateestablished/text()"/>
                  </gml:beginPosition>
                  <gml:endPosition/>
                </gml:TimePeriod>
              </wmdr:validPeriod>
            </wmdr:ResponsibleParty>
          </wmdr:responsibleParty>
          <wmdr:geospatialLocation>
            <wmdr:GeospatialLocation>
              <wmdr:geoLocation>
                <gml:Point gml:id="p1">
                  <gml:pos>
                    <xsl:value-of select="station/location/latitude/text()"/>
                    <xsl:text> </xsl:text>
                    <xsl:value-of select="station/location/longitude/text()"/>
                    <xsl:text> </xsl:text>
                    <xsl:value-of select="station/location/elevation/text()"/>
                  </gml:pos>
                </gml:Point>
              </wmdr:geoLocation>
              <wmdr:geopositioningMethod xlink:href="http://codes.wmo.int/wmdr/GeopositioningMethod/gps"/>
              <wmdr:validPeriod>
                <gml:TimePeriod gml:id="tp_geop_1">
                  <gml:beginPosition>
                    <xsl:value-of select="station/dateestablished/text()"/>
                  </gml:beginPosition>
                  <gml:endPosition/>
                </gml:TimePeriod>
              </wmdr:validPeriod>
            </wmdr:GeospatialLocation>
          </wmdr:geospatialLocation>
          <wmdr:facilityType xlink:href="http://codes.wmo.int/wmdr/FacilityType/landFixed"/>
          <wmdr:dateEstablished>
            <xsl:value-of select="station/dateestablished/text()"/>
          </wmdr:dateEstablished>
          <wmdr:wmoRegion xlink:href="http://codes.wmo.int/wmdr/WMORegion/{station/region/text()}"/>
          <wmdr:territory>
            <wmdr:Territory>
              <wmdr:territoryName xlink:href="http://codes.wmo.int/wmdr/TerritoryName/{station/country/text()}"/>
              <wmdr:validPeriod>
                <gml:TimePeriod gml:id="tp_territory_1">
                  <gml:beginPosition>
                    <xsl:value-of select="station/dateestablished/text()"/>
                  </gml:beginPosition>
                  <gml:endPosition/>
                </gml:TimePeriod>
              </wmdr:validPeriod>
            </wmdr:Territory>
          </wmdr:territory>
          <wmdr:programAffiliation>
            <wmdr:ProgramAffiliation>
              <wmdr:programAffiliation xlink:href="http://codes.wmo.int/wmdr/ProgramAffiliation/GOS"/>
              <wmdr:programSpecificFacilityId>Kilimanjaro</wmdr:programSpecificFacilityId>
            </wmdr:ProgramAffiliation>
          </wmdr:programAffiliation>
          <xsl:for-each select="station/observations/observation">
            <wmdr:observation>
              <wmdr:ObservingCapability gml:id="obsCap_{position()}">
                <wmdr:facility xlink:href="_{../../wigosid/text()}"/>
                <wmdr:programAffiliation xlink:href="GOS"/>
                <wmdr:observation>
                  <om:OM_Observation gml:id="obs_{position()}">
                    <om:type xlink:href="http://codes.wmo.int/wmdr/featureOfInterest/point"/>
                    <om:phenomenonTime>
                      <gml:TimePeriod gml:id="pt_tp_{position()}_1">
                        <gml:beginPosition>
                          <xsl:value-of select="../../dateestablished/text()"/>
                        </gml:beginPosition>
                        <gml:endPosition/>
                      </gml:TimePeriod>
                    </om:phenomenonTime>
                    <om:resultTime/>
                    <om:procedure>
                      <wmdr:Process gml:id="proc_{position()}_1">
                        <wmdr:deployment>
                          <wmdr:Deployment gml:id="depl_{position()}_1">
                            <wmdr:dataGeneration>
                              <wmdr:DataGeneration gml:id="dg_{position()}_1">
                                <wmdr:validPeriod>
                                  <gml:TimePeriod gml:id="dg_tp_{position()}_1">
                                    <gml:beginPosition>
                                      <xsl:value-of select="../../dateestablished/text()"/>
                                    </gml:beginPosition>
                                    <gml:endPosition/>
                                  </gml:TimePeriod>
                                </wmdr:validPeriod>
                                <wmdr:schedule>
                                  <wmdr:Schedule>
                                    <wmdr:startMonth>
                                      <xsl:value-of select="schedule/monthfrom/text()"/>
                                    </wmdr:startMonth>
                                    <wmdr:endMonth>
                                      <xsl:value-of select="schedule/monthto/text()"/>
                                    </wmdr:endMonth>
                                    <wmdr:startWeekday>
                                      <xsl:value-of select="schedule/dayfrom/text()"/>
                                    </wmdr:startWeekday>
                                    <wmdr:endWeekday>
                                      <xsl:value-of select="schedule/dayto/text()"/>
                                    </wmdr:endWeekday>
                                    <wmdr:startHour>
                                      <xsl:value-of select="schedule/hourfrom/text()"/>
                                    </wmdr:startHour>
                                    <wmdr:endHour>
                                      <xsl:value-of select="schedule/hourto/text()"/>
                                    </wmdr:endHour>
                                    <wmdr:startMinute>
                                      <xsl:value-of select="schedule/minuteto/text()"/>
                                    </wmdr:startMinute>
                                    <wmdr:endMinute>
                                      <xsl:value-of select="schedule/minuteto/text()"/>
                                    </wmdr:endMinute>
                                    <wmdr:diurnalBaseTime>00:00:00Z</wmdr:diurnalBaseTime>
                                  </wmdr:Schedule>
                                </wmdr:schedule>
                                <wmdr:sampling>
                                  <wmdr:Sampling>
                                    <!--  6-03 sampling strategy  -->
                                    <wmdr:samplingStrategy xlink:href="http://codes.wmo.int/common/wmdr/SamplingStrategy/continuous"/>
                                  </wmdr:Sampling>
                                </wmdr:sampling>
                                <wmdr:reporting>
                                  <wmdr:Reporting>
                                    <wmdr:internationalExchange>
                                      <xsl:value-of select="schedule/international/text()"/>
                                    </wmdr:internationalExchange>
                                    <wmdr:uom xlink:href="http://codes.wmo.int/common/unit/ppbv"/>
                                    <!--
 needs correction, ppbv does not actually exist in the code list yet 
-->
                                    <wmdr:temporalReportingInterval>PT<xsl:value-of select="schedule/interval/text()"/>S</wmdr:temporalReportingInterval>
                                  </wmdr:Reporting>
                                </wmdr:reporting>
                              </wmdr:DataGeneration>
                            </wmdr:dataGeneration>
                            <wmdr:validPeriod >
                              <gml:TimePeriod gml:id="vp_{position()}_1">
                                <gml:beginPosition>
                                  <xsl:value-of select="../../dateestablished/text()"/>
                                </gml:beginPosition>
                                <gml:endPosition/>
                              </gml:TimePeriod>
                            </wmdr:validPeriod>
                            <wmdr:applicationArea/>
                            <wmdr:sourceOfObservation xlink:href="http://codes.wmo.int/wmdr/SourceOfObservation/{observationsource/text()}"/>
                          </wmdr:Deployment>
                        </wmdr:deployment>
                      </wmdr:Process>
                    </om:procedure>
                    <om:observedProperty xlink:href="{variable/text()}"/>
                    <om:featureOfInterest/>
                    <om:result/>
                  </om:OM_Observation>
                </wmdr:observation>
              </wmdr:ObservingCapability>
            </wmdr:observation>
          </xsl:for-each>
        </wmdr:ObservingFacility>
      </wmdr:facility>
    </wmdr:WIGOSMetadataRecord>
  </xsl:template>
</xsl:stylesheet>
