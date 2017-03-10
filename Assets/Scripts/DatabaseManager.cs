using UnityEngine;
using System;
using System.Collections;
using System.Xml;

public static class DatabaseManager
{
    static string BaseDataPath = Application.dataPath;

    // The primary 
    public static object ReturnQueriedData(DataQueryType type, string objectName, string queryAttr, string queryCateg)
    {
        return GetXMLData(type, objectName, queryAttr, queryCateg);
    }

    public static object ReturnQueriedData(DataQueryType type, string objectName, string queryAttr, string queryCateg, byte idNum)
    {
        return GetXMLData(type, objectName, queryAttr, queryCateg, idNum);
    }

    private static object GetXMLData(DataQueryType type, string objectName, string queryAttr, string queryCateg, byte idNum = 0)
    {
        // Returns the file name of the XML file.
        string returnedFile = ReturnXMLFile(type);

        // Checks if the returned file name is empty. 
        // If NOT, continue down the line.
        if (returnedFile != string.Empty)
        {
            // Creates a new XmlReader instance to read through everything necessary.
            XmlReader reader = XmlReader.Create(BaseDataPath + "/Scripts/" + returnedFile);

            // While we're still reading the XML file, continue.
            while (reader.Read())
            {
                

                // Reads the XML node, and determines if it's an element and it isn't the root.
                if (reader.NodeType == XmlNodeType.Element)
                {
                    //while (reader.GetAttribute("Name") != objectName)
                    //    continue;

                    if(reader.GetAttribute("Name") == objectName)
                    {
                        // If it's anything else but the name, you must also have the category filled out.
                        if (queryCateg != string.Empty)
                        {
                            // Reads to the next descendant.
                            if (reader.ReadToDescendant(queryCateg))
                            {
                                // Checks if there's a valid ID number.
                                if (idNum != 0)
                                    GetCorrectDescendantsOfElement(reader, queryCateg, idNum);

                                // Gets the data queried element.
                                return RetrieveDataFromQueriesElement(reader, queryAttr); // Returns the data retrieved from the search.
                            }
                        }
                    }
                }
            }
         }

       return null;
    }

    // Get correct enemy element recursively.
    private static void GetCorrectEnemyElement(XmlReader reader, string objectName)
    {
        if(reader.GetAttribute("Name") != objectName)
        {
            reader.ReadToNextSibling("Enemy");
            GetCorrectEnemyElement(reader, objectName);
        }
    }

    // Iterates through the descendants recursively.
    private static void GetCorrectDescendantsOfElement(XmlReader reader, string queryCateg, byte idNum)
    {
        if (reader.GetAttribute("ID") != idNum.ToString())
        {
            reader.ReadToNextSibling(queryCateg);
            GetCorrectDescendantsOfElement(reader, queryCateg, idNum);
        }
    }

    // Get XML file.
    private static string ReturnXMLFile(DataQueryType type)
    {
        switch (type)
        {
            case DataQueryType.Enemies:
                return "Enemies.xml";
        }

        // This returns an empty string. If this somehow happens, you've made a grievous error.
        return string.Empty;
    }

    // Retrieve the data from the queried attribute.
    private static object RetrieveDataFromQueriesElement(XmlReader reader, string queryAttribute)
    {
        return reader.GetAttribute(queryAttribute);
    }
}
