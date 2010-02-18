﻿using System;
using System.ServiceModel.Channels;

// Yanked from: http://msdn.microsoft.com/en-us/library/cc716898.aspx
namespace AdamDotCom.Common.Service.Infrastructure.JSONP
{
    public class JSONPBindingElement : MessageEncodingBindingElement
    {
        WebMessageEncodingBindingElement wme = new WebMessageEncodingBindingElement();

        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return new JSONPEncoderFactory();
        }

        public override MessageVersion MessageVersion
        {
            get
            {
                return wme.MessageVersion;
            }
            set
            {
                throw new Exception("MessageVersion property cannot be set.");
            }
        }

        public override BindingElement Clone()
        {
            return new JSONPBindingElement();
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Context is null.");

            context.BindingParameters.Add(this);
            return context.BuildInnerChannelFactory<TChannel>();
        }

        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Context is null.");

            return context.CanBuildInnerChannelFactory<TChannel>();
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Context is null.");

            context.BindingParameters.Add(this);
            return context.BuildInnerChannelListener<TChannel>();
        }

        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Context is null.");

            context.BindingParameters.Add(this);
            return context.CanBuildInnerChannelListener<TChannel>();
        }

        public override T GetProperty<T>(BindingContext context)
        {
            return wme.GetProperty<T>(context);
        }
    }
}