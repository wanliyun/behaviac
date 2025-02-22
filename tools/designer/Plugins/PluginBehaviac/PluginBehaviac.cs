////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2009, Daniel Kollmann
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
//
// - Redistributions of source code must retain the above copyright notice, this list of conditions
//   and the following disclaimer.
//
// - Redistributions in binary form must reproduce the above copyright notice, this list of
//   conditions and the following disclaimer in the documentation and/or other materials provided
//   with the distribution.
//
// - Neither the name of Daniel Kollmann nor the names of its contributors may be used to endorse
//   or promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY
// WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
////////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// The above software in this distribution may have been modified by THL A29 Limited ("Tencent Modifications").
//
// All Tencent Modifications are Copyright (C) 2015-2017 THL A29 Limited.
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using Behaviac.Design;
using PluginBehaviac.Properties;

namespace PluginBehaviac
{
    /// <summary>
    /// The plugin which is loaded when you start the editor.
    /// </summary>
    public class Plugin : Behaviac.Design.Plugin
    {
        public Plugin()
        {
            // register resource manager
            AddResourceManager(Resources.ResourceManager);

            //Plugin.RegisterTypeHandlers();
            //Plugin.RegisterAgentTypes();

            // register all the groups we need in the node explorer
            //Plugin.RegisterNodeDesc();

            // register all the file managers
            _fileManagers.Add(new FileManagerInfo(typeof(Behaviac.Design.FileManagers.FileManagerXML), "Behaviour XML (*.xml)|*.xml", ".xml"));

            // register all the exporters
            //xporters.Add(new ExporterInfo(typeof(Behaviac.Design.Exporters.ExporterXml), "xml", "Xml", true));
            //Exporters.Add(new ExporterInfo(typeof(Behaviac.Design.Exporters.ExporterBson), "bson", "Bson", true));
            Exporters.Add(new ExporterInfo(typeof(PluginBehaviac.Exporters.ExporterCpp), "cpp", "C++", true, true));
            Exporters.Add(new ExporterInfo(typeof(PluginBehaviac.Exporters.ExporterCs), "cs", "C#", true, true));

            Plugin.FSMReferencedBehaviorNodeType = typeof(Nodes.FSMReferencedBehavior);
        }
    }
}
