﻿/**
 * Mobius Software LTD
 * Copyright 2015-2017, Mobius Software LTD
 *
 * This is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as
 * published by the Free Software Foundation; either version 2.1 of
 * the License, or (at your option) any later version.
 *
 * This software is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this software; if not, write to the Free
 * Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
 * 02110-1301 USA, or see the FSF site: http://www.fsf.org.
 */

using com.mobius.software.windows.iotbroker.mqtt_sn.packet.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mobius.software.windows.iotbroker.mqtt_sn.avps;
using com.mobius.software.windows.iotbroker.mqtt.exceptions;
using com.mobius.software.windows.iotbroker.mqtt_sn.headers.api;

namespace com.mobius.software.windows.iotbroker.mqtt_sn.packet.impl
{
    public class SNPuback: CountableMessage
    {
        #region private fields

        private Int32 _topicID;
        private ReturnCode _code;

        #endregion

        #region constructors

        public SNPuback()
        {
        }

        public SNPuback(Int32 topicID, Int32 messageID, ReturnCode code) :base(messageID)
        {
            this._topicID = topicID;
            this._code = code;
        }

        #endregion

        #region public fields

        public SNPuback reInit(Int32 topicID, Int32 messageID, ReturnCode code)
        {
            this._topicID = topicID;
            this.MessageID = messageID;
            this._code = code;
            return this;
        }

        override
        public int getLength()
        {
            return 7;
        }

        public override SNType getType()
        {
            return SNType.PUBACK;
        }

        public Int32 topicID
        {
            get
            {
                return _topicID;
            }

            set
            {
                _topicID = value;
            }            
        }

        public ReturnCode ReturnCode
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }

        public override void ProcessBy(SNDevice device)
        {
            device.ProcessPuback(MessageID.Value);
        }

        #endregion
    }
}