using UnityEngine.UI;

namespace TweenPlayables
{
    public class TweenGraphicMixerBehaviour : TweenAnimationMixerBehaviour<Graphic, TweenGraphicBehaviour>
    {
        private ColorValueMixer colorMixer = new();

        public override void Blend(Graphic binding, TweenGraphicBehaviour behaviour, float weight, float progress)
        {
            if (behaviour.color.IsActive)
            {
                colorMixer.Blend(behaviour.color.Evaluate(binding, progress), weight);
            }
        }

        public override void Apply(Graphic binding)
        {
            if (colorMixer.HasValue)
            {
                binding.color = colorMixer.Value;
            }

            colorMixer.Clear();
        }
    }

}