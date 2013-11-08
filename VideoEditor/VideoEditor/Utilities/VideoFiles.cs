﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using TvArchiving.Domain.Entities;


namespace VideoEditor
{
    public class VideoFiles
    {
        //private int m_fileID;
        private string m_fileName;
        private string m_filePath;
        private float m_fileLength = 86400.000000f;
        private float m_startSeconds = 0.000000f;
        private DateTime m_fileDate;
        private double m_fps = 0;
        private double m_duration = 0;

        //public VideoFiles(int fileID, string fileName, string filePath, float startSeconds, double dfps, double dDuration)
        public VideoFiles(string fileName, string filePath, float startSeconds, double dfps, double dDuration)
        {
            //m_fileID = fileID;
            m_fileName = fileName;
            m_filePath = filePath;
            m_startSeconds = startSeconds;
            m_fps = dfps;
            m_duration = dDuration;

            m_endSeconds = (float)m_startSeconds + (float)m_duration;
            float duration = (float)m_endSeconds - (float)m_startSeconds;
            m_startRatio = m_startSeconds / (float)86400.000000;
            m_endRatio = m_endSeconds / (float)86400.000000;
            shots = new Collection<Shot>();
        }

        //[Conversion(DataTableConversion = true, AllowDbNull = false)]
        //public int FileID
        //{
        //    get { return m_fileID; }
        //    set { m_fileID = value; }
        //}

        [Conversion(DataTableConversion = true, KeyField = true, AllowDbNull = false)]
        public string FileName
        {
            get { return m_fileName; }
            set { m_fileName = value; }
        }

        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public double fps
        {
            get { return m_fps; }
            set { m_fps = value; }
        }

        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public double duration
        {
            get { return m_duration; }
            set { m_duration = value; }
        }

        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public float startSeconds
        {
            get { return m_startSeconds; }
            set { m_startSeconds = value; }
        }

        [Conversion(DataTableConversion = true, KeyField = true, AllowDbNull = false)]
        public string FilePath
        {
            get { return m_filePath; }
            set { m_filePath = value; }
        }

        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public float FileLength
        {
            get { return m_fileLength; }
            set { m_fileLength = value; }
        }

        //[Conversion(DataTableConversion = true, AllowDbNull = false)]
        //public int Age
        //{
        //    get { return this.GetAge(); }
        //}

        //[Conversion(DataTableConversion = true, AllowDbNull = true)]
        //public DateTime FileDate
        //{
        //    get { return this.GetFileDate(); }
        //}

        ///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////

        private bool m_goodData = true;
        public bool goodData
        {
            get { return m_goodData; }
            set { m_goodData = value; }
        }

        private RectangleF m_recordingRect = new RectangleF();
        public RectangleF recordingRect
        {
            get { return m_recordingRect; }
            set { m_recordingRect = value; }
        }



        private float m_endSeconds = 86400.000000f;
        public float endSeconds
        {
            get { return m_endSeconds; }
            set { m_endSeconds = value; }
        }

        private Size m_size = new Size();
        public Size size
        {
            get { return m_size; }
            set { m_size = value; }
        }

        private float m_startRatio = 1.000000f;
        public float startRatio
        {
            get { return m_startRatio; }
            set { m_startRatio = value; }
        }

        private float m_endRatio = 1.000000f;
        public float endRatio
        {
            get { return m_endRatio; }
            set { m_endRatio = value; }
        }


        public ICollection<Shot> shots;

        private DateTime GetFileDate()
        {
            try
            {
                FileInfo fi = new FileInfo(m_filePath);
                m_fileDate = fi.CreationTimeUtc;
            }
            catch (Exception ex)
            {
                m_fileDate = DateTime.Now;
            }
            return m_fileDate;
        }

        private int GetAge()
        {
            int years = DateTime.Now.Year - m_fileDate.Year;

            if (DateTime.Now.Month < m_fileDate.Month ||
               (DateTime.Now.Month == m_fileDate.Month &&
               DateTime.Now.Day < m_fileDate.Day))
            {
                years--;
            }

            return years;
        }
    }
}
