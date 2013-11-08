#region framework namespaces
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Runtime;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Net;
using System.Xml;
using System.Runtime.InteropServices;
#endregion

namespace Video.Controls
{
    public class Bars
    {
        static Bars()
        {
        }

        public Bars()
        {
        }

        //private int _fileId = -1;
        //public int FileID
        //{
        //    get { return _fileId; }
        //    set { _fileId = value; }
        //}

        private String _videoFileName = string.Empty;
        public String FileName
        {
            get { return _videoFileName; }
            set { _videoFileName = value; }
        }

        private String _videoFilePath = string.Empty;
        public String FilePath
        {
            get { return _videoFilePath; }
            set { _videoFilePath = value; }
        }

        private float _fileLength = 86400.000000f;
        public float FileLength
        {
            get { return _fileLength; }
            set { _fileLength = value; }
        }

        private double _fps = 0.00d;
        public double FPS
        {
            get { return _fps; }
            set { _fps = value; }
        }

        private double _duration = 0.00d;
        public double Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        ///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////

        private bool _goodData = true;
        public bool goodData
        {
            get { return _goodData; }
            set { _goodData = value; }
        }

        private RectangleF _recordingRect = new RectangleF();
        public RectangleF recordingRect
        {
            get { return _recordingRect; }
            set { _recordingRect = value; }
        }

        private float _startSeconds = 0.000000f;
        public float startSeconds
        {
            get { return _startSeconds; }
            set { _startSeconds = value; }
        }

        private float _endSeconds = 86400.000000f;
        public float endSeconds
        {
            get { return _endSeconds; }
            set { _endSeconds = value; }
        }

        private Size _size = new Size();
        public Size size
        {
            get { return _size; }
            set { _size = value; }
        }

        private float _startRatio = 1.000000f;
        public float startRatio
        {
            get { return _startRatio; }
            set { _startRatio = value; }
        }

        private float _endRatio = 1.000000f;
        public float endRatio
        {
            get { return _endRatio; }
            set { _endRatio = value; }
        }


    }



}








