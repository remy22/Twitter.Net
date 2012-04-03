// ------------------------------------------------------------------------------------------------------
// Copyright (c) 2012, Kevin Wang
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the 
// following conditions are met:
//
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and 
//    the following disclaimer.
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions 
//    and the following disclaimer in the documentation and/or other materials provided with the distribution.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// ------------------------------------------------------------------------------------------------------

namespace Mirai.Twitter.TwitterObjects
{
    using System.Collections.Generic;

    public abstract class TwitterGeometry : TwitterObject
    {
        #region Constants and Fields

        private bool _IsCoordinate;

        protected readonly List<TwitterCoordinate> CoordinatesList;

        #endregion


        protected TwitterGeometry()
        {
            this._IsCoordinate      = false;
            this.CoordinatesList    = new List<TwitterCoordinate>();
        }

        /// <summary>
        /// If there are no coordinate, return an empty array not null.
        /// </summary>
        public TwitterCoordinate[] Coordinates
        {
            get { return this.CoordinatesList != null ? this.CoordinatesList.ToArray() : new TwitterCoordinate[] { }; }
        }


        internal bool IsCoordinate
        {
            get { return this._IsCoordinate; }
            set
            {
                if (this._IsCoordinate == value)
                    return;

                this._IsCoordinate = value;
                this.SwapLatAndLong();
            }
        }

        private void SwapLatAndLong()
        {
            foreach (var coordinate in CoordinatesList)
            {
                var tmp                 = coordinate.Latitude;
                coordinate.Latitude     = coordinate.Longitude;
                coordinate.Longitude    = tmp;
            }
        }
    }
}