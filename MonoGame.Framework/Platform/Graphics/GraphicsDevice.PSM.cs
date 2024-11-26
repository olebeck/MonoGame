// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;

using MonoGame.Framework.Utilities;

using Sce.PlayStation.Core.Graphics;
using PssVertexBuffer = Sce.PlayStation.Core.Graphics.VertexBuffer;


namespace Microsoft.Xna.Framework.Graphics
{
    public partial class GraphicsDevice
    {
        internal GraphicsContext _graphics;
        internal List<PssVertexBuffer> _availableVertexBuffers = new List<PssVertexBuffer>();
        internal List<PssVertexBuffer> _usedVertexBuffers = new List<PssVertexBuffer>();
        internal GraphicsContext Context {
            get
            {
                return _graphics;
            }
            set
            {
                _graphics = value;
            }
        }

        private void PlatformSetup()
        {
            MaxTextureSlots = 8;
            _maxVertexBufferSlots = 1;
        }

        private void PlatformInitialize()
        {
            _graphics = new GraphicsContext();
        }

        public void PlatformClear(ClearOptions options, Vector4 color, float depth, int stencil)
        {
            // TODO: We need to figure out how to detect if we have a
            // depth stencil buffer or not, and clear options relating
            // to them if not attached.

            _graphics.SetClearColor(color.ToPssVector4());
            _graphics.Clear();
        }

        private void PlatformDispose()
        {

            if (_graphics != null)
            {
                _graphics.Dispose();
                _graphics = null;
            }
        }

        public void PlatformPresent()
        {
            _graphics.SwapBuffers();
            _availableVertexBuffers.AddRange(_usedVertexBuffers);
            _usedVertexBuffers.Clear();
        }

        private void PlatformSetViewport(ref Viewport value)
        {
            _graphics.SetViewport(
                value.X, value.Y, value.Width, value.Height
            );
        }

        private void PlatformApplyDefaultRenderTarget()
        {
            _graphics.SetFrameBuffer(_graphics.Screen);
        }

        internal void PlatformResolveRenderTargets()
        {
            // Resolving MSAA render targets should be done here.
        }

        private IRenderTarget PlatformApplyRenderTargets()
        {
            var renderTarget = (RenderTarget2D)_currentRenderTargetBindings[0].RenderTarget;
            _graphics.SetFrameBuffer(renderTarget._frameBuffer);

            return renderTarget;
        }

        internal void PlatformBeginApplyState()
        {
            // TODO: This was on both the OpenGL and PSM path previously - is it necessary?
            //Threading.EnsureUIThread();
        }

        internal void PlatformApplyState(bool applyShaders)
        {
            if ( _scissorRectangleDirty ) {
                _graphics.SetScissor(_scissorRectangle.ToPSSImageRect());
                _scissorRectangleDirty = false;
            }

            // If we're not applying shaders then early out now.
            if (!applyShaders)
                return;

            if (_indexBufferDirty)
                _indexBufferDirty = false;

            if (_vertexShader == null)
                throw new InvalidOperationException("A vertex shader must be set!");
            if (_pixelShader == null)
                throw new InvalidOperationException("A pixel shader must be set!");

            Textures.SetTextures(this);
            SamplerStates.PlatformSetSamplers(this);
        }

        private void PlatformDrawIndexedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount)
        {
            BindVertexBuffer(true);
            ApplyState(true);
            _graphics.DrawArrays(PSSHelper.ToDrawMode(primitiveType), startIndex, GetElementCountArray(primitiveType, primitiveCount));
        }

        private void PlatformDrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, VertexDeclaration vertexDeclaration, int vertexCount) where T : struct
        {
            throw new NotImplementedException("Not implemented");
        }

        private void PlatformDrawPrimitives(PrimitiveType primitiveType, int vertexStart, int vertexCount)
        {
            BindVertexBuffer(false);
            _graphics.DrawArrays(PSSHelper.ToDrawMode(primitiveType), vertexStart, vertexCount);
        }

        private void PlatformDrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, short[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct
        {
            throw new NotImplementedException("Not implemented");
        }

        private void PlatformDrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, int[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct
        {
            throw new NotImplementedException("Not implemented");
        }

        private void PlatformDrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount, int baseInstance, int instanceCount)
        {
            BindVertexBuffer(true);
            ApplyState(true);
            _graphics.DrawArraysInstanced(PSSHelper.ToDrawMode(primitiveType), startIndex, primitiveCount, baseInstance, instanceCount);
        }

        internal PssVertexBuffer GetVertexBuffer(VertexFormat[] vertexFormat, int requiredVertexLength, int requiredIndexLength)
        {
            int bestMatchIndex = -1;
            PssVertexBuffer bestMatch = null;
            
            //Search for a good one
            for (int i = _availableVertexBuffers.Count - 1; i >= 0; i--)
            {
                var buf = _availableVertexBuffers[i];

                // Check there is enough space
                if (buf.VertexCount != requiredVertexLength)
                    continue;
                if (requiredIndexLength == 0 && buf.IndexCount != 0)
                    continue;
                if (requiredIndexLength > 0 && buf.IndexCount != requiredIndexLength)
                    continue;

                // Check VertexFormat is the same
                var bufFormats = buf.Formats;
                if (vertexFormat.Length != bufFormats.Length)
                    continue;
                bool allEqual = true;
                for (int j = 0; j < bufFormats.Length; j++)
                {
                    if (vertexFormat[j] != bufFormats[j])
                    {
                        allEqual = false;
                        break;
                    }
                }
                if (!allEqual)
                    continue;

                //this one is acceptable
                
                //No current best or this one is smaller than the current best
                if (bestMatch == null || (buf.IndexCount + buf.VertexCount) < (bestMatch.IndexCount + bestMatch.VertexCount))
                {
                    bestMatch = buf;
                    bestMatchIndex = i;
                }
            }
            
            if (bestMatch != null)
            {
                return bestMatch;
            }
            else
            {
                //Create one
                bestMatch = new PssVertexBuffer(requiredVertexLength, requiredIndexLength, vertexFormat);
            }
            _usedVertexBuffers.Add(bestMatch);
            
            return bestMatch;
        }
        
        /// <summary>
        /// Set the current _graphics VertexBuffer based on _vertexBuffer and _indexBuffer, reusing an existing VertexBuffer if possible
        /// </summary>
        private void BindVertexBuffer(bool bindIndexBuffer)
        {
            var _vertexBufferBinding = _vertexBuffers.Get(0);
            var _vertexBuffer = _vertexBufferBinding.VertexBuffer;
            int requiredIndexLength = (!bindIndexBuffer || _indexBuffer == null) ? 0 : _indexBuffer.IndexCount;
            
            var vertexFormat = _vertexBuffer.VertexDeclaration.GetVertexFormat();
            
            var vertexBuffer = GetVertexBuffer(vertexFormat, _vertexBuffer.VertexCount, requiredIndexLength);
            
            vertexBuffer.SetVertices(_vertexBuffer._vertexArray);
            if (requiredIndexLength > 0)
                vertexBuffer.SetIndices(_indexBuffer._buffer);
            
            _graphics.SetVertexBuffer(0, vertexBuffer);
        }

        private static GraphicsProfile PlatformGetHighestSupportedGraphicsProfile(GraphicsDevice graphicsDevice)
        {
           return GraphicsProfile.HiDef;
        }

        internal void PlatformSetMultiSamplingToMaximum(PresentationParameters presentationParameters, out int quality)
        {
            quality = 0;
        }

        private static Rectangle PlatformGetTitleSafeArea(int x, int y, int width, int height)
        {
            return new Rectangle(x, y, width, height);
        }

        internal void OnPresentationChanged()
        {
            ApplyRenderTargets(null);
        }

        private void PlatformApplyBlend(bool force = false)
        {
            _actualBlendState.PlatformApplyState(this, force);
            ApplyBlendFactor(force);
        }
        
        private void ApplyBlendFactor(bool force)
        {
        }

        private void PlatformGetBackBufferData<T>(Rectangle? rectangle, T[] data, int startIndex, int count) where T : struct
        {
            var rect = rectangle ?? new Rectangle(0, 0, PresentationParameters.BackBufferWidth, PresentationParameters.BackBufferHeight);
            var tSize = ReflectionHelpers.FastSizeOf<T>();
            #warning fixme, data[T] thing
            //_graphics.ReadPixels(data, PixelFormat.Rgba, rect.X, rect.Y, rect.Width, rect.Height);
        }
    }
}
